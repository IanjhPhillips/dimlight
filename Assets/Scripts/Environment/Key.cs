using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public enum KeyColor { orange, blue, green, red };
    public const int COLOR_COUNT = 4;

    SpriteRenderer keySpriteRenderer;
    public Sprite[] keySprites;
    public KeyColor keyColor;

    // Start is called before the first frame update
    void Start()
    {
        keySpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keySpriteRenderer.sprite == null)
        {
            keySpriteRenderer.sprite = keySprites[(int)keyColor];
        }
    }

    public void SetKey(KeyColor _keyColor)
    {
        keyColor = _keyColor;
        keySpriteRenderer.sprite = keySprites[(int)keyColor];
    }

    public void AddKeyToPlayer(PlayerMovement player)
    {
        player.addKey(keyColor);
        keySpriteRenderer.enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.SetActive(false);
    }

}