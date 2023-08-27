using UnityEngine;

public class ChoiceButton : MonoBehaviour
{
    public int ChoiceID { get; set; }

    public void MakeChoice()
    {
        FindAnyObjectByType<DialogueController>().SelectChoice(ChoiceID);
    }
}