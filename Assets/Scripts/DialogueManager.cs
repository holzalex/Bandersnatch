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
        if(dialogueActive && Input.GetKeyDown(KeyCode.Return))
        {
          currentLine++;
        }
        if(currentLine >= dialogueLines.Length)
        {
              dialogueBox.SetActive(false);
              dialogueActive = false;

              currentLine = 0;
              player.canMove = true;
        }

        dialogueText.text = dialogueLines[currentLine];
    }

    

    public void ShowDialogue()
    {
        player.canMove = false;
        dialogueActive = true;
        dialogueBox.SetActive(true);
        
    }
}
