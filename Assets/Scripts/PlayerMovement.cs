using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Vorher Festgelegte Geschwindigkeit des Players
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }
    void Update()
    {
            moveSpeed = 5f;
    // Wenn Player sich nicht bewegen darf, setze Geschwindigkeit auf 0
         if(!canMove)
        {
            moveSpeed = 0f;
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
            return;
            
        }
    // Geschwindigkeit wird erfasst um Animationen abzuspielen
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
// Schräge Bewegungen Normalisiert
    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

}
