using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldmanMovement : MonoBehaviour
{

    public float moveSpeed, walkTime, waitTime, walkCounter, waitCounter;
    private Vector2 minWalkPoint, maxWalkPoint;
    public bool isWalking, hasWalkZone, canWalk;
    private int WalkDirection;
    private Rigidbody2D myRigidbody; 
    public Collider2D walkZone;
    private Animator anim;
    private DialogueManager dialogueManager;
    

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        canWalk = true;
        anim = GetComponent<Animator>();


        
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;
        
        ChooseDirection();
    // Legt eine Zone fest in der ein NPC laufen kann, wenn vorhanden
        if(walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }   
    }

    // Update is called once per frame
    void Update()
    {
    // Wenn kein Dialog aktiv ist, darf der NPC herumlaufen
        if(!dialogueManager.dialogueActive)
        {
            canWalk = true;
        }
    // sonst setze Geschwindigkeit auf 0
        if(!canWalk){
            myRigidbody.velocity = Vector2.zero;
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 0); 
            return;
        }
            
        Vector2 v2 = myRigidbody.velocity;
        anim.SetFloat("MoveX", v2.x);
        anim.SetFloat("MoveY", v2.y);
        
        if(isWalking){
    // Sekundenzähler
            walkCounter -= Time.deltaTime;
    // Sobald Zähler auf 0 ist, starte Wartezähler      !!
            if(walkCounter < 0){
                isWalking = false;
                waitCounter = waitTime;
            }
    // NPC sucht sich eine Richtung aus in die er läuft 
            switch(WalkDirection){
                case 0: // oben
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;

                case 1: // rechts
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                      if(hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;

                case 2: // unten
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                      if(hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;

                case 3: // links
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                      if(hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;
            }

        }
        else { // tritt ein sobald eine Walkzonegrenze erreicht wurde
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(waitCounter < 0){
                ChooseDirection();
            }
        }
        
    }
    // Zufällige Zahlenauswahl
    public void ChooseDirection(){
        WalkDirection = Random.Range(0,4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
