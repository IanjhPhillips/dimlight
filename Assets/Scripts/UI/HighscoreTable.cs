using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private GameObject Difficulty;
    [SerializeField] private Text Score;

    // Start is called before the first frame update
    void Start()
    {
        Score.text = PlayerPrefs.GetString("highscore_" + Difficulty.GetComponent<DifficultyButton>().getDifficulty().ToString(), "Boblin has yet to escape on this difficulty!");
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = PlayerPrefs.GetString("highscore_" + Difficulty.GetComponent<DifficultyButton>().getDifficulty().ToString(), "Boblin has yet to escape on this difficulty!");
    }
}
