using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAndDoorSpawner : MonoBehaviour
{
    public GameObject[] doorPrefabs;
    public GameObject[] keyPrefabs;

    //recall enum KeyColor {orange, blue, green, red}
    public GameObject[] orangeThresholds, blueThresholds, greenThresholds, redThresholds;
    public GameObject[] orangeKeySpawns, blueKeySpawns, greenKeySpawns, redKeySpawns;

    // Start is called before the first frame update
    void Start()
    {
        SpawnOneThreshold(orangeThresholds);
        SpawnOneThreshold(redThresholds);
        SpawnOneThreshold(blueThresholds);
        SpawnOneThreshold(greenThresholds);

        SpawnOneKey(orangeKeySpawns, keyPrefabs[0]);
        SpawnOneKey(blueKeySpawns, keyPrefabs[1]);
        SpawnOneKey(greenKeySpawns, keyPrefabs[2]);
        SpawnOneKey(redKeySpawns, keyPrefabs[3]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnOneThreshold (GameObject[] thresholds)
    {
        if (thresholds.Length < 1)
        {
            return;
        }

        GameObject threshold = thresholds[Random.Range(0, thresholds.Length)];

        foreach (GameObject t in thresholds)
        {
            if (!t.Equals(threshold))
            {
                Destroy(t);
            }
                
        }
    }

    private void SpawnOneKey (GameObject[] spawns, GameObject key)
    {
        if (spawns.Length < 1)
        {
            return;
        }

        GameObject spawn = spawns[Random.Range(0, spawns.Length)];

        Instantiate(key, spawn.transform.position, Quaternion.identity);
    }
}
