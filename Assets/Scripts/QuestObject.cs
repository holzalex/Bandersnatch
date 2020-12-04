using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public int questnr;
    public QuestManager questManager;
    public string startText;
    public string endText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startQuest()
    {
        questManager.showQuestText(startText);
    }

    public void endQuest()
    {
        questManager.showQuestText(endText);
        questManager.questCompleted[questnr] = true;
        gameObject.SetActive(false);
    }
}
