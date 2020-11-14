﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Tutorial : MonoBehaviour
{
    private int Tutorial;

    // Start is called before the first frame update
    private void Start()
    {
        Tutorial = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(Tutorial);
    }
}
