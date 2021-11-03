using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    SpriteRenderer doorSpriteRenderer;
    public Sprite[] doorClosedSprites;
    public Key.KeyColor doorColor;
    public Sprite doorOpenSprite;
    public bool isDoorOpen = false;
    public BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        doorSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorSpriteRenderer.sprite == null)
        {
            SetDoor(doorColor, isDoorOpen);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!isDoorOpen && other.gameObject.tag == "Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            if (player.keys.Contains(doorColor))
            {
                isDoorOpen = true;
                SetDoor(doorColor, isDoorOpen);
            }
        }
    }

    public void SetDoor (Key.KeyColor _doorColor, bool isOpen)
    {
        if (isOpen)
        {
            doorSpriteRenderer.sprite = doorOpenSprite;
            gameObject.GetComponent<Collider2D>().enabled = false;
            return;
        }
        doorColor = _doorColor;
        doorSpriteRenderer.sprite = doorClosedSprites[(int)doorColor];
    }
}
