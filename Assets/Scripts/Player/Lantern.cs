using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{
    private float[] difficultyFuel = { 3000f, 2000f, 1000f };

    PlayerMovement player;

    private bool active;
    public float maxFuel;
    private float currentFuel;
    public float baseFuelConsumptionRate;
    private float fuelConsumptionRate;
    private float baseDiameter = 10f;
    private float diameter;

    private float userMod = 0f;
    private float modStep = 0.5f;
    private float maxMod = 3f;
    private float minMod = -3f;

    private Vector3 localScaleOn, localScaleOff;
    // Start is called before the first frame update
    void Start()
    {
        //initialize difficulty settings
        maxFuel = difficultyFuel[GameManager.getDifficulty()];

        //get dependencies
        player = transform.parent.gameObject.GetComponent<PlayerMovement>();

        fuelConsumptionRate = baseFuelConsumptionRate;
        diameter = baseDiameter;

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

        float modInput = getLanternModInput();
        if (modInput != 0f)
        {
            userMod += modInput * modStep;
            boundMod();
            SetDiameter(userMod);
            localScaleOn = new Vector3(diameter, diameter, 1f);
            SetScale();
            fuelConsumptionRate = baseFuelConsumptionRate + 20 * userMod;
        }


        
    }

    private float getLanternModInput()
    {
        bool positive = Input.GetKeyDown("up") || Input.GetKeyDown("right");
        bool negative = Input.GetKeyDown("down") || Input.GetKeyDown("left");

        return (positive ? 1f : 0f) + (negative? -1f : 0f);
    }

    //Set Lantern active state and scale (future: animation states)
    public void SetActive(bool input)
    {
        if (active != input)
        {
            if (input && currentFuel > 0)
            {
                active = true;
                SetScale();
            }
            else
            {
                active = false;
                SetScale();
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

    private void SetScale()
    {
        transform.localScale = active ? localScaleOn : localScaleOff;
    }

    private void boundMod ()
    {
        if (userMod > maxMod)
        {
            userMod = maxMod;
        }
        if (userMod < minMod)
        {
            userMod = minMod;
        }
    }

    private void SetDiameter(float delta)
    {
        diameter = baseDiameter + delta;
    }

}

