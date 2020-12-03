using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    public string dialogue;
    private DialogueManager dialogueManager;

    public string[] dialogueLines;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            if(Input.GetKeyUp(KeyCode.Return))
            {
                if(!dialogueManager.dialogueActive)
                {
                    dialogueManager.dialogueLines = this.dialogueLines;
                    dialogueManager.currentLine = 0;
                    dialogueManager.ShowDialogue();
                }
                    if(transform.parent.GetComponent<OldmanMovement>() != null)
                    {
                        transform.parent.GetComponent<OldmanMovement>().canWalk = false;
                    }
            }

        }

    }

}
