using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private bool hasPlayer;
    private PlayerMovement player;
    private bool active;

    public float damage = 2f;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        hasPlayer = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        if (hasPlayer)
        {
            player.Damage(damage);
        }
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    public void setHasPlayer(bool b)
    {
        hasPlayer = b;
    }

    public bool isActive ()
    {
        return active;
    }
}
