using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreEntry
{
    public float score;
    public string name;
    public string difficulty;

    public ScoreEntry(float score, string name, string difficulty)
    {
        this.score = score;
        this.name = name;
        this.difficulty = difficulty;
    }
}
