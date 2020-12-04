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

    //Konfrontationsumgang zwischen dem NPC und dem Spieler
    void OnTriggerStay2D(Collider2D other)
    {
        //UEberpruefung ob ein Spieler in der Kollider-Box ist
        if(other.name == "Player")
        {
            //Enter-Taste wird gedrueckt
            if(Input.GetKeyUp(KeyCode.Return))
            {
                //Oeffnung eines Dialoges
                if(!dialogueManager.dialogueActive)
                {
                    dialogueManager.dialogueLines = this.dialogueLines;
                    dialogueManager.currentLine = 0;
                    dialogueManager.ShowDialogue();
                }
                    //Ueberpruefung ob die Old-Man sich bewegt
                    if(transform.parent.GetComponent<OldmanMovement>() != null)
                    {
                        //Bewegungseinschraenkung des Old-Man
                        transform.parent.GetComponent<OldmanMovement>().canWalk = false;
                    }
            }

        }

    }

}
