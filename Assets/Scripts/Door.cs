using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    SpriteRenderer doorSprite;
    public Sprite[] doorColors;
    public string[] colors = {"red", "orange", "green", "blue"};
    public string doorColor;
    public Sprite doorOpen;
    public bool isDoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        doorSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (doorSprite.sprite == null && doorColor != null)
        {
            doorSprite.sprite = doorColors[Array.IndexOf(colors, doorColor)];
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
                doorSprite.sprite = doorOpen;
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
