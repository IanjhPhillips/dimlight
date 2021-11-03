/***************************************************************************************
*   Credits go to the authod this Youtube tutorial on how to build a color changing health bar
*   This code is inspired from the contents of the video with some modifications to fit
*   our game's requirements.
*   
*    Title: Three Cool Health Bars in Unity (2021/2020)
*    Author: Mousawi Dev
*    Date: August 27th 2020
*    Availability: https://youtu.be/ZzkIn41DFFo
*
***************************************************************************************/

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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
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

