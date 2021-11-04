using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public enum Difficulty {Easy,Medium,Hard}
    public Text difficultyText;
    public Button difficultyButton;
    private Difficulty selectedDifficulty;


    private void Start()
    {
        Button btn = difficultyButton.GetComponent<Button>();
        btn.onClick.AddListener(NextDifficulty);
        selectedDifficulty = Difficulty.Easy;
        difficultyText.text = selectedDifficulty.ToString();
    }

    void NextDifficulty() 
    {
        switch (selectedDifficulty) 
        {
            case Difficulty.Easy:
                selectedDifficulty = Difficulty.Medium;
                difficultyText.text = selectedDifficulty.ToString();
                break;
            case Difficulty.Medium:
                selectedDifficulty = Difficulty.Hard;
                difficultyText.text = selectedDifficulty.ToString();
                break;
            case Difficulty.Hard:
                selectedDifficulty = Difficulty.Easy;
                difficultyText.text = selectedDifficulty.ToString();
                break;
        }
    }

    public Difficulty getDifficulty() 
    {
        return selectedDifficulty;
    }
}
