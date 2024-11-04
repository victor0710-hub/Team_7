using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player1_Movement : MonoBehaviour
{
    public float speed = 5f;
    public bool isPlayerOne = true; // Set this to false for Player 2
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get references to the Animator and SpriteRenderer components
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;

        // Check for input based on which player this is
        if (isPlayerOne)
        {
            // WASD Controls for Player 1
            if (Input.GetKey(KeyCode.W))
                moveY = 1f;
            else if (Input.GetKey(KeyCode.S))
                moveY = -1f;
            if (Input.GetKey(KeyCode.A))
                moveX = -1f;
            else if (Input.GetKey(KeyCode.D))
                moveX = 1f;
        }
        else
        {
            // Arrow Key Controls for Player 2
            if (Input.GetKey(KeyCode.UpArrow))
                moveY = 1f;
            else if (Input.GetKey(KeyCode.DownArrow))
                moveY = -1f;
            if (Input.GetKey(KeyCode.LeftArrow))
                moveX = -1f;
            else if (Input.GetKey(KeyCode.RightArrow))
                moveX = 1f;
        }

        // Set movement direction and update position
        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        transform.Translate(moveDirection * speed * Time.deltaTime);

        // Animation control
        bool isWalking = moveDirection.magnitude > 0;
        animator.SetBool("Walk", isWalking);

        // Corrected Flip Logic
        if (moveX > 0)
        {
            spriteRenderer.flipX = true; // Facing right
        }
        else if (moveX < 0)
        {
            spriteRenderer.flipX = false; // Facing left
        }
    }
}

