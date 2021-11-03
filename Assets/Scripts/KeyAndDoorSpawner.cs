using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAndDoorSpawner : MonoBehaviour
{
    public GameObject doorPrefab;
    public GameObject keyPrefab;

    //recall enum KeyColor {orange, blue, green, red}
    public GameObject[] orangeThresholds, blueThresholds, greenThresholds, redThresholds;
    public GameObject[] orangeKeySpawns, blueKeySpawns, greenKeySpawns, redKeySpawns;

    // Start is called before the first frame update
    void Start()
    {

        GameObject exampleDoorObject = Instantiate(doorPrefab, new Vector3(-5.5f, 1.5f, -1.0f), Quaternion.identity);
        Door exampleDoor = exampleDoorObject.GetComponent<Door>();
        exampleDoor.doorColor = (Key.KeyColor) Random.Range(0, Key.COLOR_COUNT);
        Debug.Log("Generating a " + exampleDoor.doorColor.ToString() + " door.");

        GameObject exampleKeyObject = Instantiate(keyPrefab, new Vector3(0.0f, 0.0f, -1.0f), Quaternion.identity);
        Key exampleKey = exampleKeyObject.GetComponent<Key>();
        exampleKey.keyColor = exampleDoor.doorColor;
        Debug.Log("Generating a " + exampleKey.keyColor.ToString() + " key.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
