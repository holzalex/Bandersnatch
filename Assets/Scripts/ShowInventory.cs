using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    public GameObject inventarSlot;
    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        inventarSlot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) {
            //Vertausche den Wert des Booleans
            isActive = !isActive;
            inventarSlot.SetActive(isActive);
        }
    }
}
