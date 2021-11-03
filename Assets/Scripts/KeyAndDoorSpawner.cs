using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAndDoorSpawner : MonoBehaviour
{
    public GameObject doorPrefab;
    public GameObject keyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameObject exampleDoorObject = Instantiate(doorPrefab, new Vector3(-5.5f, 1.5f, -1.0f), Quaternion.identity);
        Door exampleDoor = exampleDoorObject.GetComponent<Door>();
        exampleDoor.doorColor = exampleDoor.colors[Random.Range(0, exampleDoor.colors.Length)];
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
