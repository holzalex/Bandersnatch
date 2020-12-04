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
    // Escape Taste startet oder beendet das Pausemenü
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
    // Friert die Zeit ein
        Time.timeScale = 0f;
        istPausiert = true;
    }
    
    public void WiedergabeGame()
    {
        pausenMenue.SetActive(false);
    // Stellt Zeit auf den Norm
        Time.timeScale = 1f;
        istPausiert = false;
    }

    public void HQLoader()
    {
    // Wechselt Szene zu "HQ"
        SceneManager.LoadScene("HQ");
        Time.timeScale = 1f;
        istPausiert = false;
    }

    public void HauptmenueLoader()
    {
    // Wechselt Szene zu "Hauptmenü"
        SceneManager.LoadScene("Hauptmenü");
        Time.timeScale = 1f;
        istPausiert = false;
    }
}
