using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Lantern lantern;
    private GameObject lanternObject;

    private SpriteRenderer spriteRend;
    private Animator animator;

    public float speed;
    private bool active;
    private float respawnTime;
    public float lifeTimeMin = 10f, lifeTimeMax = 30f;

    private bool lanternIsActive;
    private float lanternRadius;

    private float spawnDistanceFromPlayer;
    private const float LANTERN_BUFFER_DISTANCE = 1f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        lanternObject = GameObject.FindGameObjectWithTag("Lantern");
        lantern = lanternObject.GetComponent<Lantern>();

        lanternRadius = lantern.getRadius();
        lanternIsActive = lantern.isActive();

        spawnDistanceFromPlayer = Random.Range(lanternRadius + LANTERN_BUFFER_DISTANCE, lanternRadius*2);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= respawnTime && active)
        {
            Respawn();
        }
        if (active)
        {
            Move();
        }
        
    }

    private void Spawn ()
    {
        print("spawning: " +  gameObject);
        active = true;
        animator.SetBool("active", active);
        respawnTime = Time.time + Random.Range(lifeTimeMin, lifeTimeMax);
        float spawnAngle = Random.Range(0f, 2f) * Mathf.PI; //random angle in radians
        Vector2 dir = new Vector2(Mathf.Cos(spawnAngle), Mathf.Sin(spawnAngle)); //vector corresponding to the angle
        dir = dir.normalized; //possibly redundant?
        transform.position = (Vector2) lanternObject.transform.position + dir * spawnDistanceFromPlayer;
    }

    public void Respawn ()
    {
        active = false;
        animator.SetBool("active", active);
        print("fading: " + gameObject);
    }

    private void Move ()
    {
        Vector2 target = GetMoveTarget();
        transform.position = Vector2.MoveTowards(transform.position, target, speed);
        spriteRend.flipX = ((Vector2) transform.position - target).x < 0;
    }

    private Vector2 GetMoveTarget ()
    {
        lanternIsActive = lantern.isActive();
        Vector2 position = transform.position;
        Vector2 lanternPosition = lanternObject.transform.position;
        Vector2 lanternOffset = position - lanternPosition;
        float distanceToLantern = lanternOffset.magnitude;
        lanternRadius = lantern.getRadius();

        Vector2 target;

        if (lanternIsActive && distanceToLantern < lanternRadius + LANTERN_BUFFER_DISTANCE)
        {
            target = position + lanternOffset.normalized;
        }
        else if (lanternIsActive && distanceToLantern > lanternRadius + LANTERN_BUFFER_DISTANCE)
        {
            target = GetLanternEdgeTarget();
        }
        else if (!lanternIsActive)
        {
            target = lanternPosition;
        }
        else
        {
            target = transform.position;
        }
        return target;
    }

    // imagine a straight line between this and the lantern
    // find position on line that intersects with lantern radius
    private Vector2 GetLanternEdgeTarget ()
    {
        Vector2 dir = transform.position - lanternObject.transform.position;
        dir = dir.normalized;
        return (Vector2) lanternObject.transform.position + dir * (lantern.getRadius() + LANTERN_BUFFER_DISTANCE);
    }
}
