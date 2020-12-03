using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetAnim : MonoBehaviour
{
    public Animator transition;
    private PlayerMovement player;
    public float transitionTime = 1f;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetLevel();
        Destroy(player.gameObject);
    }

    public void ResetLevel()
    {
        StartCoroutine(Reset(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator Reset(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);        //Scene loading wartet x viele Sekunden auf Animation

        //Reset Scene
        SceneManager.LoadScene(levelIndex);
    }
}
