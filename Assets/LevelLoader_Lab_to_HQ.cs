using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_Lab_to_HQ : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LoadNextLevel();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 2));
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
