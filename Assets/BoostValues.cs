using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostValues : MonoBehaviour
{
    public static BoostValues instance;
    public float fuelIncrease = 10000f;
    public float healthIncrease = 1f;
    public float speedIncrease = 1f;
    public float speedIncreaseDuration = 7f;
    public float torchDuration = 7f;
    public float invulnerabilityDuration = 7f;

    private void Awake()
    {
        instance = this;
    }

    public float GetFuelIncrease() 
    {
        return fuelIncrease;
    }

    public float GetHealthIncrease()
    {
        return healthIncrease;
    }

    public float GetSpeedIncrease()
    {
        return speedIncrease;
    }

    public float GetSpeedIncreaseDuration()
    {
        return speedIncreaseDuration;
    }

    public float GetTorchDuration()
    {
        return torchDuration;
    }
    public float GetInvulnerabilityDuration()
    {
        return invulnerabilityDuration;
    }
}

