using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdKills : MonoBehaviour
{
    public Animator transition;
    public GameObject text2;
    private DestroyText text;
    private PlayerMovement player;
    public float transitionTime = 1f;

    void Start()
    {  
        player = FindObjectOfType<PlayerMovement>();
        text = FindObjectOfType<DestroyText>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ResetLevel();
        Destroy(player.gameObject);
        text.enableText();
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
