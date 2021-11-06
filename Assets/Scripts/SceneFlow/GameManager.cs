using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager manager;

    private bool fail;
    private string failureMessage;

    public int startTime;
    public int endTime;


    private void Awake()
    {
        if (manager == null)
        {
            manager = this;
            DontDestroyOnLoad(gameObject);
            fail = false;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = (int) Time.time;
        failureMessage = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene (int i)
    {
        if (i == SceneManager.sceneCountInBuildSettings - 1)
        {
            EndTimer();
        }
        SceneManager.LoadScene(i);
    }

    public void Failure (string message)
    {
        failureMessage = message;
        fail = true;
        ReloadScene();
    }

    private void ReloadScene ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public string GetFailureMessage()
    {
        if (fail)
        {
            fail = false;
            return failureMessage; 
        }
        return "";
    }

    public void StartTimer ()
    {
        startTime = (int) Time.time;
    }

    public void EndTimer ()
    {
        endTime = (int) Time.time;
    }

    public bool getFail ()
    {
        return fail;
    }
}
