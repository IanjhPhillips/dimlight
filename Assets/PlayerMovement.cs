using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    Vector2 movement;
    public bool spacebarStatus;

    // Update is called once per frame
    // Update will handle data inputs
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        spacebarStatus = Input.GetKey("space");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("SpacebarStatus",spacebarStatus);
    }

    //Fixed Update is called based on a fixed timer (50 times a second default)
    //Fixed update will handle movement
    void FixedUpdate() 
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
