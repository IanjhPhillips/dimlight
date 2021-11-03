using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelButton : MonoBehaviour
{
    public Text selectedLevelText;
    public Button levelButton;
    private int selectedLevel;
    public int numberOfLevels;

    // Start is called before the first frame update
    void Start()
    {

        Button btn = levelButton.GetComponent<Button>();
        btn.onClick.AddListener(NextLevel);
        selectedLevel = 1;
        selectedLevelText.text = "Level " + selectedLevel.ToString();
    }
    void NextLevel()
    {
        if (selectedLevel < numberOfLevels) 
        {
            selectedLevel += 1;
            selectedLevelText.text = "Level " + selectedLevel.ToString();
        }
        else
        {
            selectedLevel = 1;
            selectedLevelText.text = "Level " + selectedLevel.ToString();
        }
    }

}
