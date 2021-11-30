using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTwinkle : MonoBehaviour
{
    float maxWaitTime = 3f;
    float minWaitTime = 1f;
    float waitTime = 0f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartRecharge();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRecharge()
    {
        print("here");
        StartCoroutine(Recharge());
        
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        animator.ResetTrigger("play");
        animator.SetTrigger("play");
    }


}
