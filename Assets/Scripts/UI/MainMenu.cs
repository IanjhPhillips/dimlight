using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject HighscoreTable;
    public void PlayGame() 
    {
        PlayerPrefs.SetString("difficulty", GameObject.Find("DifficultyButton").GetComponent<DifficultyButton>().getDifficulty().ToString());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void ShowHighscores() 
    {
        gameObject.SetActive(false);
        HighscoreTable.SetActive(true);
    }
    public void Back()
    {
        HighscoreTable.SetActive(false);
        gameObject.SetActive(true);
    }
}
