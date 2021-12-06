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
        if (GameObject.Find("NameInput").GetComponent<Text>().text == "")
        {
            completionName = "Boblin";
        }
        else
        {
            completionName = GameObject.Find("NameInput").GetComponent<Text>().text;
        }

        if (PlayerPrefs.GetString("scores", "empty") == "empty")
        {
            HighscoreTable.Scores scores = new HighscoreTable.Scores();
            scores.ScoreEntries.Add(new ScoreEntry(completionTime, completionName, completionDifficulty));
            string json = JsonUtility.ToJson(scores);
            PlayerPrefs.SetString("scores", json);
            PlayerPrefs.Save();
        }
        else 
        {
            HighscoreTable.Scores scores = JsonUtility.FromJson<HighscoreTable.Scores>(PlayerPrefs.GetString("scores"));
            scores.ScoreEntries.Add(new ScoreEntry(completionTime, completionName, completionDifficulty));
            string json = JsonUtility.ToJson(scores);
            PlayerPrefs.SetString("scores", json);
            PlayerPrefs.Save();
        }
        GameManager.manager.LoadScene(0);
    }
}
