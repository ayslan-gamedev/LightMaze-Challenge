using UnityEngine;

public class DialogueInvoke : MonoBehaviour
{
    [SerializeField] private DialogueFile dialogueToStart;
    private DialogueController controller;

    private const string PLAYER_TAG = "Player";

    public bool OnStartScript;
    public bool OnTriggerEnter;
    public bool DestroyOnStart;

    void Start()
    {
        controller = FindAnyObjectByType<DialogueController>();
        
        if(controller != null && OnStartScript)
        {
            controller.StartDialogue(dialogueToStart);
            Destroy();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(PLAYER_TAG) && controller != null && OnTriggerEnter)
        {
            controller.StartDialogue(dialogueToStart);
            Destroy();
        }
    }

    private void Destroy()
    {
        if(DestroyOnStart)
        {
            Destroy(gameObject);
        }
    }
}