using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTwinkle : MonoBehaviour
{
    public float maxWaitTime;
    public float minWaitTime;
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
        StartCoroutine(Recharge());
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        animator.ResetTrigger("play");
        animator.SetTrigger("play");
    }


}
