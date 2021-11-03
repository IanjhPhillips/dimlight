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
    private bool hasTorch;

    public float maxHealth = 10f;
    private float currentHealth;
    private bool isInvulnerable;

    public List<string> keys = new List<string>();

    private void Start()
    {
        hasTorch = false;
        isInvulnerable = false;
        currentHealth = maxHealth;
        HealthBar.instance.SetupHealth((int)currentHealth);
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

        HealthBar.instance.SetCurrentHealth(currentHealth);

    }

    //Fixed Update is called based on a fixed timer (50 times a second default)
    //Fixed update will handle movement
    void FixedUpdate() 
    {
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void UpdateLantern ()
    {
        if (hasTorch)
        {
            lantern.SetActive(true);

        }
        else 
        {
            lantern.SetActive(spacebarStatus);
        }
    }

    public void Die (string message)
    {
        print(message);
        //restart level
    }

    public void Damage(float d)
    {
        if (!isInvulnerable) 
        {
            currentHealth -= d;
        }
        if (currentHealth <= 0)
        {
            Die("Out of HP");
        }
    }

    public void setCurrentHealth(float _health)
    {
        if (_health > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else 
        {
            currentHealth = _health;
        }
    }

    public float getCurrentHealth ()
    {
        return currentHealth;
    }

    public float getMaxHealth ()
    {
        return maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ghost"))
        {
            Damage(0.25f);
            collision.gameObject.GetComponent<Ghost>().Respawn();
        }
        if (collision.CompareTag("FuelBoost"))
        {
            lantern.setCurrentFuel(lantern.getCurrentFuel() + BoostValues.instance.GetFuelIncrease());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("HealthBoost"))
        {
            setCurrentHealth(currentHealth + BoostValues.instance.GetHealthIncrease());
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("SpeedBoost"))
        {
            moveSpeed += BoostValues.instance.GetSpeedIncrease();
            Destroy(collision.gameObject);
            StartCoroutine(ResetSpeed());
        }
        if (collision.CompareTag("TorchBoost"))
        {
            hasTorch = true;
            Destroy(collision.gameObject);
            StartCoroutine(ResetTorch());
        }
        if (collision.CompareTag("InvulnerabilityBoost"))
        {
            isInvulnerable = true;
            Destroy(collision.gameObject);
            StartCoroutine(ResetInvulnerability());
        }
    }


    private IEnumerator ResetSpeed() 
    {
        yield return new WaitForSeconds(BoostValues.instance.GetSpeedIncreaseDuration());
        moveSpeed -= BoostValues.instance.GetSpeedIncrease();
    }

    public bool GetTorchStatus()
    {
        return hasTorch;
    }

    private IEnumerator ResetTorch()
    {
        yield return new WaitForSeconds(BoostValues.instance.GetTorchDuration());
        hasTorch = false;    
    }


    public bool GetInvulnerabilityStatus()
    {
        return isInvulnerable;
    }

    private IEnumerator ResetInvulnerability()
    {
        yield return new WaitForSeconds(BoostValues.instance.GetInvulnerabilityDuration());
        isInvulnerable = false;
    }
}
