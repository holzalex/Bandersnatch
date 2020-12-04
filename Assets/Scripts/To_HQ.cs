using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_HQ : MonoBehaviour
{
    private int HQ;

    // Start is called before the first frame update
    private void Start()
    {
    // Setzt HQ auf den Index der HQ Szene
        HQ = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Sobald der 2D Collider betreten wird, wird die Szene am Index "HQ" geladen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(HQ);
    }
}
