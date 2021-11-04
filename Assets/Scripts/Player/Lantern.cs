using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    PlayerMovement player;

    private bool active;
    public float maxFuel;
    private float currentFuel;
    public float fuelConsumptionRate;
    private float diameter = 10f;

    private Vector3 localScaleOn, localScaleOff;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject.GetComponent<PlayerMovement>();

        //save these as to avoid creating new vectors every frame
        localScaleOn = new Vector3(diameter, diameter, 1f);
        localScaleOff = new Vector3(0f, 0f, 0f);

        //initialize state
        active = false;
        transform.localScale = localScaleOff;
        currentFuel = maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (!player.GetTorchStatus()) 
            {
                currentFuel -= fuelConsumptionRate * Time.deltaTime;
            }
            FuelBar.instance.SetFuel(currentFuel);
        }

        if (currentFuel <= 0)
        {
            currentFuel = 0;
            SetActive(false);
            player.Die("Out of fuel");
        }
    }

    //Set Lantern active state and scale (future: animation states)
    public void SetActive(bool input)
    {
        if (active != input)
        {
            if (input && currentFuel > 0)
            {
                active = true;
                transform.localScale = active ? localScaleOn : localScaleOff;
            }
            else
            {
                active = false;
                transform.localScale = active ? localScaleOn : localScaleOff;
            }
                
        }
    }

    public bool isActive()
    {
        return active;
    }

    //Mutators on radius, currentFuel and maxFuel
    public float getRadius()
    {
        return this.diameter / 2f;
    }

    public void setRadius(float _radius)
    {
        this.diameter = _radius;
    }
    
    public float getCurrentFuel ()
    {
        return this.currentFuel;
    }

    public void setCurrentFuel (float _fuel)
    {
        if (_fuel > maxFuel)
        {
            this.currentFuel = maxFuel;
        }
        else 
        {
            this.currentFuel = _fuel;
        }
    }

    public float getMaxFuel()
    {
        return this.maxFuel;
    }

    public void setMaxFuel(float _maxFuel)
    {
        this.maxFuel = _maxFuel;
    }

}

