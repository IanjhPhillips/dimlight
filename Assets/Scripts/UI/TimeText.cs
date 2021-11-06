using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour
{
    private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int time = (int) Time.time - GameManager.manager.startTime;
        timeText.text = "Time: " + time;
    }
}
