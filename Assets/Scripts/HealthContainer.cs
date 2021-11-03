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
using UnityEngine.UI;

public class HealthContainer : MonoBehaviour
{
    public HealthContainer next;

    [Range(0, 1)] float fill;
    [SerializeField] Image fillImage;

    public void SetHealth(float count) 
    {
        fill = count;
        fillImage.fillAmount = fill;
        count--;
        if (next != null) 
        {
            next.SetHealth(count);
        }
    }
}
