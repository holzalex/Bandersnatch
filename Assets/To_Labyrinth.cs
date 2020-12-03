using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Labyrinth : MonoBehaviour
{
    private int Labyrinth;

    // Start is called before the first frame update
    private void Start()
    {
        Labyrinth = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(Labyrinth);
    }
}
