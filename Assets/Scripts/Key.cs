using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    SpriteRenderer keySprite;
    public Sprite[] keyColors;
    public string[] colors = {"red", "orange", "green", "blue"};
    public string keyColor;

    // Start is called before the first frame update
    void Start()
    {
        keySprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keySprite.sprite == null && keyColor != null)
        {
            keySprite.sprite = keyColors[Array.IndexOf(colors, keyColor)];
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();
            player.keys.Add(keyColor);
            keySprite.enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
