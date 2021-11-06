using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Stairs : MonoBehaviour
{
    public int nextIndex;

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        print("scenecount: " + SceneManager.sceneCountInBuildSettings);

        if (!SceneInfo.info.lastStage)
        {
            nextIndex = SceneManager.GetActiveScene().buildIndex + 1;
        }
        else
        {
            nextIndex = SceneManager.sceneCountInBuildSettings - 1;
        }

        print(nextIndex);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNext()
    {
        GameManager.manager.LoadScene(nextIndex);
    }
}
