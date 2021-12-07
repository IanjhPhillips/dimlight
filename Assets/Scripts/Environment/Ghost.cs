using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float[] difficultyMaxLifeTimes;
    public float[] difficultyMinLifeTimes;
    public float[] difficultySpeeds;


    private Lantern lantern;
    private GameObject lanternObject;

    private SpriteRenderer spriteRend;
    private Animator animator;

    private float speed;
    private float setSpeed;
    private float speedMod = 250f;
    private bool active;
    private float respawnTime;
    private float lifeTimeMin, lifeTimeMax;
    public bool isBig;

    private bool lanternIsActive;
    private float lanternRadius;

    private float spawnDistanceFromPlayer;
    private const float LANTERN_BUFFER_DISTANCE = 1f;

    // Start is called before the first frame update
    void Start()
    {
        int difficulty = GameManager.getDifficulty();

        lifeTimeMin = difficultyMinLifeTimes[difficulty];
        lifeTimeMax = difficultyMaxLifeTimes[difficulty];
        speed = difficultySpeeds[difficulty];

        setSpeed = speed;

        spriteRend = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();

        lanternObject = GameObject.FindGameObjectWithTag("Lantern");
        lantern = lanternObject.GetComponent<Lantern>();

        lanternRadius = lantern.getRadius();
        lanternIsActive = lantern.isActive();

        spawnDistanceFromPlayer = Random.Range(10f, 20f);
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            speed = setSpeed;
            if (Time.time >= respawnTime && active)
            {
                Respawn();
            }
            if (active)
            {
                Move();
            }
        }
        else 
        {
            speed = 0f;
        }
    }

    private void Spawn ()
    {
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
    }

    private void Move ()
    {
        Vector2 target = GetMoveTarget();
        transform.position = Vector2.MoveTowards(transform.position, target, speed*speedMod*Time.deltaTime);
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
        if (isBig || !lanternIsActive)
        {
            target = lanternPosition;
        }
        else if (lanternIsActive && distanceToLantern < lanternRadius + LANTERN_BUFFER_DISTANCE)
        {
            target = position + lanternOffset.normalized;
        }
        else if (lanternIsActive && distanceToLantern > lanternRadius + LANTERN_BUFFER_DISTANCE)
        {
            target = GetLanternEdgeTarget();
        }
        else
        {
            target = transform.position;
        }
        return target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Candle") && !isBig)
        {
            Respawn();
        }
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
