using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hauptmenü : MonoBehaviour
{
    public void Spielstart() {
        SceneManager.LoadScene("HQ");
    }
}
