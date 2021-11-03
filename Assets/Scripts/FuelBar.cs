using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    public static FuelBar instance;
    public Image fuelBar;
    float currentFuel, maxFuel;
    float lerpSpeed;

    private void Start()
    {
        instance = this;
        currentFuel = maxFuel = GameObject.FindGameObjectWithTag("Lantern").GetComponent<Lantern>().getMaxFuel();
    }

    private void Update()
    {
        FuelBarFiller();
        if (currentFuel > maxFuel) 
        {
            currentFuel = maxFuel;
        }

        lerpSpeed = 9f* Time.deltaTime;
        ColorChanger();
    }

    void ColorChanger()
    {
        Color fuelColor = Color.Lerp(Color.red, Color.yellow, currentFuel/maxFuel);
        fuelBar.color = fuelColor;
    }

    void FuelBarFiller() 
    {
        if (fuelBar.fillAmount > 0.01) 
        { 
            fuelBar.fillAmount = Mathf.Lerp(fuelBar.fillAmount, currentFuel/maxFuel, lerpSpeed);
        }
    }

    public void SetFuel(float fuel) 
    {
        currentFuel = fuel;
    }
}

