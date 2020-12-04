using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questnr;
    public QuestManager questManager;
    public string startText;
    public string endText;
    // Start is called before the first frame update/ Zurzeit noch nicht verwendet
    void Start()
    {
        
    }

    // Update is called once per frame/ Zurzeit noch nicht verwendet
    void Update()
    {
        
    }

// Startet die Quest, indem sie den Startquesttext als Dialog anzeigt
    public void startQuest()
    {
        questManager.showQuestText(startText);
    }
// Beendet die Quest indem sie den Endquesttext als Dialog anzeigt, zudem wird die Quest als bewältigt markiert und deaktiviert
    public void endQuest()
    {
        questManager.showQuestText(endText);
        questManager.questCompleted[questnr] = true;
        gameObject.SetActive(false);
    }
}
