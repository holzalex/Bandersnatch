using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hauptmenü : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public void Spielstart() {
        SceneManager.LoadScene("HQ");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);        //Scene loading wartet x viele Sekunden auf Animation

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }
}
