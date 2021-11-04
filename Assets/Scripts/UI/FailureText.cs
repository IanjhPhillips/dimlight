using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailureText : MonoBehaviour
{
    private Text failureText;
    private string failureMessage;

    // Start is called before the first frame update
    void Start()
    {
        failureText = gameObject.GetComponent<Text>();
        failureMessage = GameManager.manager.GetFailureMessage();
        failureText.text = failureMessage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
