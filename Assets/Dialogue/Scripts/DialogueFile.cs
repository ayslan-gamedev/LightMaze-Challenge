using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/DialogueLine")]
public class DialogueFile : ScriptableObject
{
    [TextArea(1, 1)] public string Speaker;
    [TextArea(3, 20)] public List<string> textDialogue;
    public List<DialogueChoices> choices;
}

[System.Serializable]
public struct DialogueChoices 
{
    [TextArea(3, 20)] public string textChoices;
    public DialogueFile nextDialogue;
}