﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_HQ2 : MonoBehaviour
{
    private int HQ;

    // Start is called before the first frame update
    private void Start()
    {
        HQ = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(HQ);
    }
}