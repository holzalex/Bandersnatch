using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausenMenü : MonoBehaviour
{

    public GameObject pausenMenue;
    public bool istPausiert;

    // Start is called before the first frame update
    void Start()
    {
        pausenMenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(istPausiert)
                WiedergabeGame();
            
            else
                PausiereGame();
        }
    }

    public void PausiereGame()
    {
        pausenMenue.SetActive(true);
        Time.timeScale = 0f;
        istPausiert = true;
    }

    public void WiedergabeGame()
    {
        pausenMenue.SetActive(false);
        Time.timeScale = 1f;
        istPausiert = false;
    }

    public void HQLoader()
    {
        SceneManager.LoadScene("HQ");
        Time.timeScale = 1f;
        istPausiert = false;
    }

    public void HauptmenueLoader()
    {
        SceneManager.LoadScene("Hauptmenü");
        Time.timeScale = 1f;
        istPausiert = false;
    }
}
