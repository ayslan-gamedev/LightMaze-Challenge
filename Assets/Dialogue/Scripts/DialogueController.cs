using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private DialogueUIElements uiElements;
    [SerializeField] private GameObject buttonChoicesPrefab;
    [SerializeField] private GameObject UIDialogue;
    [SerializeField] private GameObject[] buttons;

    private DialogueFile CurrentDialogueFile { get; set; }
    private int CurrentDialogueLine { get; set; }

    private readonly string[] buttonNextValues = { ">>>", "exit" };

    /// <summary>
    /// Display the dialogue in the UI.
    /// </summary>
    private void WriteDialogue()
    {
        // Display the speaker's name.
        uiElements.UISpeakerText.text = CurrentDialogueFile.Speaker;
        // Display the current dialogue text.
        uiElements.UIText.text = CurrentDialogueFile.textDialogue[CurrentDialogueLine];
    }

    /// <summary>
    /// Handle choice selection.
    /// Used by the Unity editor.
    /// </summary>
    /// <param name="button">Selected button (continue/back).</param>
    public void PassButtons(int button)
    {
        switch(button)
        {
            case 0:
                CurrentDialogueLine--;
                break;

            case 1:
                CurrentDialogueLine++;
                break;
        }

        // habilit back button
        if(CurrentDialogueLine == 0)
        {
            buttons[0].SetActive(false);
        }
        else if(buttons[0].activeSelf == false)
        {
            buttons[0].SetActive(true);
        }

        // Checks if diaogue ends and have choices
        if(CurrentDialogueLine + 1 >= CurrentDialogueFile.textDialogue.Count && CurrentDialogueFile.choices.Count > 0)
        {
            buttons[1].SetActive(false);
            WriteChoice();
        }
        else if(CurrentDialogueLine >= CurrentDialogueFile.textDialogue.Count) // no have choices
        {
            buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = buttonNextValues[1];
            EndDialogue();
        }
        else
        {
            buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = buttonNextValues[0];
            buttons[1].SetActive(true);
        }

        // Ensure CurrentDialogueLine is not less than zero or greater than the number of dialogue lines.
        CurrentDialogueLine = Math.Clamp(CurrentDialogueLine, 0, CurrentDialogueFile.textDialogue.Count - 1);
        WriteDialogue();
    }

    private readonly List<Button> choiceButtons = new();

    /// <summary>
    /// Display the dialogue choices in the UI.
    /// </summary>
    private void WriteChoice()
    {
        // Clear the list of choice buttons.
        choiceButtons.Clear();

        // Create all choice buttons in the UI.
        for(int i = 0; i < CurrentDialogueFile.choices.Count; i++)
        {
            choiceButtons.Add(Instantiate(buttonChoicesPrefab, uiElements.ChoicesGameObject.transform).GetComponent<Button>());
            choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = CurrentDialogueFile.choices[i].textChoices;
            choiceButtons[i].GetComponent<ChoiceButton>().ChoiceID = i;
        }
    }

    /// <summary>
    /// Handle choice selection.
    /// Used by the Unity editor.
    /// </summary>
    /// <param name="choice">Number of the selected choice corresponding to a button.</param>
    public void SelectChoice(int choice)
    {
        if(CurrentDialogueFile.choices[choice].nextDialogue != null)
        {
            CurrentDialogueLine = 0;
            StartDialogue(CurrentDialogueFile.choices[choice].nextDialogue);
        }
        else
        {
            EndDialogue();
        }

        for(int i = 0; i <  choiceButtons.Count; i++)
        {
            Destroy(choiceButtons[i].gameObject);
        }

        choiceButtons.Clear();
    }

    /// <summary>
    /// End the dialogue and turn off the UI.
    /// </summary>
    private void EndDialogue()
    {
        UIDialogue.SetActive(false);
    }

    /// <summary>
    /// Initialize the dialogue script.
    /// </summary>
    /// <param name="dialogueFile">The dialogue file to read.</param>
    public void StartDialogue(DialogueFile dialogueFile)
    {
        CurrentDialogueLine = 0;
        CurrentDialogueFile = dialogueFile;
        WriteDialogue();

        UIDialogue.SetActive(true);

        buttons[0].SetActive(false);
        buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = buttonNextValues[0];
        buttons[1].SetActive(true);
    }
}

[System.Serializable]
public struct DialogueUIElements
{
    public GameObject ChoicesGameObject;
    public Image SpeakerImage;
    public TextMeshProUGUI UISpeakerText;
    public TextMeshProUGUI UIText;
}