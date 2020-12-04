using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public bool dialogueActive;
    public string[] dialogueLines;
    public int currentLine;
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Anzeige der naechste Zeile des Dialoges
        if(dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
          currentLine++;
        }
        //Ueberpruefung, ob der Dialog zuende ist
        if(currentLine >= dialogueLines.Length)
        {
              dialogueBox.SetActive(false);
              dialogueActive = false;

              currentLine = 0;
              player.canMove = true;
        }
        //Zeigt die aktuellen Zeilen des Dialoges an
        dialogueText.text = dialogueLines[currentLine];
    }

    
    //Zeigt das Dialog an und beschraenkt den Spieler der Bewegung ein
    public void ShowDialogue()
    {
        player.canMove = false;
        dialogueActive = true;
        dialogueBox.SetActive(true);
        
    }
}
