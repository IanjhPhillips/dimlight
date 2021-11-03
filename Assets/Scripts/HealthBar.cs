/***************************************************************************************
*   Credits go to the authod this Youtube tutorial on how to build a Zelda-like health bar
*   This code is inspired from the contents of the video with some modifications to fit
*   our game's requirements.
*   
*   Title: How to Code and Create Zelda Hearts Health Bar in Unity
*    Author: Info Gamer
*    Date: January 12th 2021
*    Availability: https://youtu.be/yeFTUBm0PbM
*
***************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;

    [SerializeField] GameObject healthContainerPrefab;

    [SerializeField] List<GameObject> healthContainers;
    int totalHealth;
    float currentHealth;
    HealthContainer currentContainer;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        healthContainers = new List<GameObject>();
    }

    public void SetupHealth(int healthIn) 
    {
        healthContainers.Clear();
        for (int i = transform.childCount - 1; i >= 0; i--) 
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        totalHealth = healthIn;
        currentHealth = (float)totalHealth;

        for (int i = 0; i < totalHealth; i++) 
        {
            GameObject newHealth = Instantiate(healthContainerPrefab, transform);
            healthContainers.Add(newHealth);
            if (currentContainer != null) 
            {
                currentContainer.next = newHealth.GetComponent<HealthContainer>();
            }
            currentContainer = newHealth.GetComponent<HealthContainer>();
        }
        currentContainer = healthContainers[0].GetComponent<HealthContainer>();
    }

    public void SetCurrentHealth(float health) 
    {
        currentHealth = health;
        currentContainer.SetHealth(currentHealth);
    }

    public void AddContainer() 
    {
        GameObject newHeathContainer = Instantiate(healthContainerPrefab, transform);
        currentContainer = healthContainers[healthContainers.Count - 1].GetComponent<HealthContainer>();
        healthContainers.Add(newHeathContainer);

        if (currentContainer != null) 
        {
            currentContainer.next = newHeathContainer.GetComponent<HealthContainer>();
        }
        currentContainer.next = healthContainers[0].GetComponent<HealthContainer>();

        totalHealth++;
        currentHealth = totalHealth;
        SetCurrentHealth(currentHealth);
    }
}
