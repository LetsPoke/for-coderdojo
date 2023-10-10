using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

using System.IO;
using System.Linq;
using System.Net.Mime;
//using UnityEditor.VersionControl;



public class PlayerMovementCODO : MonoBehaviour
{
    private float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;
    public PlayerState currentState;
    Vector2 movement;
    void Start() {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        moveSpeed = 3.75f;
    }

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal"); //input
        movement.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();


        movement.Normalize();
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateAnimationAndMove()
    {
        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);

            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }
    
    

}
