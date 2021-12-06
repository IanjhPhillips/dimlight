using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    public class Scores
    {
        public List<ScoreEntry> ScoreEntries = new List<ScoreEntry>();
    }

    [SerializeField] private Transform ScoreContainer;
    [SerializeField] private Transform ScoreTemplate;
    [SerializeField] private Text NoScoreText;   
    private List<Transform> ScoreTransforms;
    private List<ScoreEntry> ScoreEntries;

    // Start is called before the first frame update
    void Awake()
    {
        /*
        Scores temp = new Scores();
        temp.ScoreEntries.Add(new ScoreEntry(5, "Boblin", "Easy"));
        temp.ScoreEntries.Add(new ScoreEntry(6, "Boblin", "Easy"));
        temp.ScoreEntries.Add(new ScoreEntry(7, "Boblin", "Easy"));
        string json = JsonUtility.ToJson(temp);
        PlayerPrefs.SetString("scores", json);
        PlayerPrefs.Save();*/
        SetDifficulty("Easy");
    }

    private void SortScoreEntries(List<ScoreEntry> scoreEntries) 
    {
        for (int i = 0; i < scoreEntries.Count; i++) 
        {
            for (int j = 0; j < scoreEntries.Count; j++) 
            {
                if (scoreEntries[j].score > scoreEntries[i].score) 
                {
                    ScoreEntry temp = scoreEntries[i];
                    scoreEntries[i] = scoreEntries[j];
                    scoreEntries[j] = temp;
                }
            }
        }
    }

    private void CreateScoreTransform(ScoreEntry scoreEntry, Transform Scores, List<Transform> transforms) 
    {
        Transform scoreTransform = Instantiate(ScoreTemplate, Scores);
        scoreTransform.Find("PositionText").GetComponent<Text>().text = (transforms.Count + 1).ToString() + ".";
        scoreTransform.Find("NameScoreText").GetComponent<Text>().text = scoreEntry.name + " has escaped in " + scoreEntry.score +" seconds";
        RectTransform scoreRectTransform = scoreTransform.GetComponent<RectTransform>();
        scoreRectTransform.anchoredPosition = new Vector2(0, -45f * transforms.Count);
        scoreTransform.gameObject.SetActive(true);
        transforms.Add(scoreTransform);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreContainer.childCount == 1)
        {
            NoScoreText.gameObject.SetActive(true);
        }
        else
        {
            NoScoreText.gameObject.SetActive(false);
        }
    }

    public void SetDifficulty(string difficulty)
    {
        for (int i = 0; i < ScoreContainer.childCount; i++) 
        {
            if (i != 0) 
            { 
                Destroy(ScoreContainer.GetChild(i).gameObject);
            }
        }

        ScoreTransforms = new List<Transform>();
        if (PlayerPrefs.GetString("scores", "empty") != "empty")
        {
            Scores scores = JsonUtility.FromJson<Scores>(PlayerPrefs.GetString("scores"));
            print(scores.ScoreEntries.Count);
            SortScoreEntries(scores.ScoreEntries);
            int counter = 0;
            foreach (ScoreEntry scoreEntry in scores.ScoreEntries)
            {
                if (counter < 5) 
                {
                    if (scoreEntry.difficulty == difficulty)
                    {
                        CreateScoreTransform(scoreEntry, ScoreContainer, ScoreTransforms);
                        counter++;
                    }
                }
            }
        }
        else
        {
            NoScoreText.gameObject.SetActive(true);
        }
    }

}


