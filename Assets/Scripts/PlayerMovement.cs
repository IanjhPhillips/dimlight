using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rigidBody;
    public Animator animator;
    Vector2 movement;
    private bool spacebarStatus;

    public GameObject lanternObj;
    private Lantern lantern;

    private void Start()
    {
        if (lanternObj == null)
            lanternObj = GameObject.Find("Lantern");
        lantern = lanternObj.GetComponent<Lantern>();
    }

    // Update is called once per frame
    // Update will handle data inputs
    void Update()
    {
        //get movement input vector
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        //handle lantern input
        spacebarStatus = Input.GetKey("space");
        UpdateLantern();

        //set animator params
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);
        //animator.SetBool("SpacebarStatus",spacebarStatus); //parameter does not yet exist. commenting to supress warnings
    }

    //Fixed Update is called based on a fixed timer (50 times a second default)
    //Fixed update will handle movement
    void FixedUpdate() 
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateLantern ()
    {
        lantern.SetActive(spacebarStatus);
    }


}
