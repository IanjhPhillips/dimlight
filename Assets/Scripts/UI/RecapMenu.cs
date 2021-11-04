using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapMenu : MonoBehaviour
{
    public GameObject difficultyTextObject, timeTextObject;

    // Start is called before the first frame update
    void Start()
    {
        Text difficultyText = difficultyTextObject.GetComponent<Text>();
        difficultyText.text = "Difficulty: " + PlayerPrefs.GetString("difficulty");

        Text timeText = timeTextObject.GetComponent<Text>();
        timeText.text = "Your Time: " + (GameManager.manager.endTime - GameManager.manager.startTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu ()
    {
        GameManager.manager.LoadScene(0);
    }
}
