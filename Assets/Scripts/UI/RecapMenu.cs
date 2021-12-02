using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecapMenu : MonoBehaviour
{
    public GameObject difficultyTextObject, timeTextObject;
    private float completionTime;
    private string completionName;
    private string completionDifficulty;

    // Start is called before the first frame update
    void Start()
    {
        Text difficultyText = difficultyTextObject.GetComponent<Text>();
        completionDifficulty = PlayerPrefs.GetString("difficulty");
        difficultyText.text = "Difficulty: " + completionDifficulty;

        Text timeText = timeTextObject.GetComponent<Text>();
        completionTime = (GameManager.manager.endTime - GameManager.manager.startTime);
        timeText.text = "Your Time: " + completionTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenu ()
    {
        //If score has not been set yet, set it to completion time
        if (PlayerPrefs.GetFloat("score_" + completionDifficulty, 0f) == 0f)
        {
            PlayerPrefs.SetFloat("score_"+completionDifficulty, completionTime);
        }

        if (completionTime <= PlayerPrefs.GetFloat("score_" + completionDifficulty))
        {
            PlayerPrefs.SetFloat("score_" + completionDifficulty, completionTime);
            if (GameObject.Find("NameInput").GetComponent<Text>().text == "")
            {
                completionName = "Boblin";
            }
            else
            {
                completionName = GameObject.Find("NameInput").GetComponent<Text>().text;
            }
            PlayerPrefs.SetString("highscore_" + completionDifficulty, completionName + " escaped on " + completionDifficulty + " in " + completionTime + " seconds.");
        }
        
        GameManager.manager.LoadScene(0);
    }
}
