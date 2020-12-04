using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{

    public QuestObject[] quests;
    public bool[] questCompleted;
    public DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
    // Speichert alle Fertigen Quests
        questCompleted = new bool[quests.Length];
    }

    // Update is called once per frame/ Zurzeit noch nicht verwendet
    void Update()
    {
        
    }

    // Gibt den Questtext aus
    public void showQuestText(string questText)
    {
        
        dialogueManager.dialogueLines = new string[1];
        dialogueManager.dialogueLines[0] = questText;

        dialogueManager.currentLine = 0;
        dialogueManager.ShowDialogue();
    }
}
