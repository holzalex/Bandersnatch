﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Labyrinth : MonoBehaviour
{
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Labyrinth");
    }
}
