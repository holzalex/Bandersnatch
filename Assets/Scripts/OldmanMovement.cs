using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldmanMovement : MonoBehaviour
{

    public float moveSpeed;

    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    public bool isWalking;

    public float walkTime;
    public float waitTime;

    private int WalkDirection;
    private float walkCounter;
    private float waitCounter;
    private Rigidbody2D myRigidbody; 

    public Collider2D walkZone;

    private bool hasWalkZone;

    private Animator anim;
    
    public bool canWalk;

    public TextBoxManager tbm;

    // Start is called before the first frame update
    void Start()
    {
        tbm = FindObjectOfType<TextBoxManager>();
        canWalk = true;
        anim = GetComponent<Animator>();


        
        myRigidbody = GetComponent<Rigidbody2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;
        
        ChooseDirection();
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
        if(!canWalk){
            myRigidbody.velocity = Vector2.zero;
            anim.SetFloat("MoveX", 0);
            anim.SetFloat("MoveY", 0); 
            return;
        }
            
        Vector3 v3 = myRigidbody.velocity;
        anim.SetFloat("MoveX", v3.x);
        anim.SetFloat("MoveY", v3.y);
        if(isWalking){
            walkCounter -= Time.deltaTime;

            if(walkCounter < 0){
                isWalking = false;
                waitCounter = waitTime;
            }

            switch(WalkDirection){
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;

                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                      if(hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;

                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                      if(hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;

                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                      if(hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                break;
            }

        }
        else {
            waitCounter -= Time.deltaTime;

            myRigidbody.velocity = Vector2.zero;

            if(waitCounter < 0){
                ChooseDirection();
            }
        }
        
    }

    public void ChooseDirection(){
        WalkDirection = Random.Range(0,4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
