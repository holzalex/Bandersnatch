﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextBoxManager : MonoBehaviour {

public GameObject textBox;
public Text theText;

public TextAsset textFile;
public string[] textLines;

public int currentLine;
public int endAtLine;

public PlayerMovement player;
public OldmanMovement oldman;

public bool isActive;

public bool StopPlayerMovement;

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<PlayerMovement>();
        oldman = FindObjectOfType<OldmanMovement>();

      if(textFile != null){
          textLines = (textFile.text.Split('\n'));
      }

        if(endAtLine == 0){
            endAtLine = textLines.Length - 1;
        }
        
        if(isActive){
            EnableTextBox();
        } 
        else{
            DisableTextBox();
        }
    }


      // Update is called once per frame
    void Update()
    {
        if(!isActive){
            return;
        }
        theText.text = textLines[currentLine];

        if(Input.GetKeyDown(KeyCode.Return))
        {
            
            if(currentLine < endAtLine){
            currentLine += 1;
            }
         
         if (currentLine >= endAtLine){
            DisableTextBox();
         }
        }
    }

    public void EnableTextBox(){
        textBox.SetActive(true);
        isActive = true;
        StopPlayerMovement = true;
        if(StopPlayerMovement)
        {
            player.canMove = false;
            oldman.canWalk = false;
        }
    }

    public void DisableTextBox(){
        textBox.SetActive(false);
        isActive = false;

        player.canMove = true;
        oldman.canWalk = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
