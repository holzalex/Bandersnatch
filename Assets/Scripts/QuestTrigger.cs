using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;

    public int questNumber;
    public bool startQuest,endQuest;
    // Start is called before the first frame update
    void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame/ Zurzeit noch nicht benutzt
    void Update()
    {
        
    }
    // Wird ausgeführt sobald ein Objekt den Collider betritt
    void OnTriggerEnter2D(Collider2D other)
    {
    // Methode wird nur weitergeführt wenn Objekt "Player" heißt um, aktivierung durch NPC o.ä zu verhindern
        if(other.gameObject.name == "Player")
        {
    // Überprüft ob die Quest bereits erledigt wurde
            if(!questManager.questCompleted[questNumber])
            {
    // Überprüft ob der Collider eine Quest startet und ob die Quest nicht bereits aktiv ist
                if(startQuest && !questManager.quests[questNumber].gameObject.activeSelf)
                {
    // Quest wird aktiv gesetzt und gestartet
                    questManager.quests[questNumber].gameObject.SetActive(true);
                    questManager.quests[questNumber].startQuest();
                }
    // Überprüft ob der Collider eine Quest beendet und ob die Quest überhaupt aktiv ist
                if(endQuest && questManager.quests[questNumber].gameObject.activeSelf)
                {
    // Setzt die aktive Quest als beendet an
                    questManager.quests[questNumber].endQuest();
                }
            }
        }
    }
}
