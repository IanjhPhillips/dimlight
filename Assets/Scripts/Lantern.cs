using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lantern : MonoBehaviour
{

    private bool active;
    public float maxFuel;
    private float currentFuel;
    public float fuelConsumptionRate;
    private float radius;

    private Vector3 localScaleOn, localScaleOff;
    // Start is called before the first frame update
    void Start()
    {
        radius = 10f;
        //save these as to avoid creating new vectors every frame
        localScaleOn = new Vector3(radius, radius, 1f);
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
            currentFuel -= fuelConsumptionRate;
            FuelBar.instance.SetFuel(currentFuel);
        }
    }

    //Set Lantern active state and scale (future: animation states)
    public void SetActive(bool input)
    {
        if (active != input)
        {
            print("setting lantern: " + active);
            active = input;
            transform.localScale = active ? localScaleOn : localScaleOff;
        }
    }

    //Mutators on radius, currentFuel and maxFuel
    public float getRadius()
    {
        return radius;
    }

    public void setRadius(float _radius)
    {
        radius = _radius;
    }
    
    public float getCurrentFuel ()
    {
        return currentFuel;
    }

    public void setCurrentFuel (float _fuel)
    {
        currentFuel = _fuel;
    }

    public float getMaxFuel()
    {
        return maxFuel;
    }

    public void setMaxFuel(float _maxFuel)
    {
        maxFuel = _maxFuel;
    }
}
