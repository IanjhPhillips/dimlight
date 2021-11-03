using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    public GameObject ghostPrefab;
    public int ghostAmount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < ghostAmount; i++)
        {
            Instantiate(ghostPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
