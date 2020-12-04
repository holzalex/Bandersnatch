using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Tutorial : MonoBehaviour
{
    private int Tutorial;

    // Start is called before the first frame update
    private void Start()
    {
    // Setzt Tutorial auf den Index der Tutorial Szene
        Tutorial = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Sobald der 2D Collider betreten wird, wird die Szene am Index "Tutorial" geladen
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.LoadScene(Tutorial);
    }
}
