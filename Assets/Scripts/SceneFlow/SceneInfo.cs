using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{
    public enum SceneType {Menu, Game, Recap}
    public SceneType type = SceneType.Game;

    public bool firstStage = false;
    public bool lastStage = false;

    public static SceneInfo info;

    private void Awake()
    {
        info = this;
        if (firstStage && !GameManager.manager.getFail())
        {
            GameManager.manager.StartTimer();
        }
    }

    public void Start()
    {
        
    }
}
