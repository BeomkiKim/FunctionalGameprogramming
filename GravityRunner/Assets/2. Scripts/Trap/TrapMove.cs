using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapMove : MonoBehaviour
{
    float nextTime = 6.0f;
    float time = 0;
    float speedRandom;

    private void Update()
    {
        speedRandom = Random.Range(-2.5f, -1.25f);

        time += Time.deltaTime;
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        velocity.x = speedRandom;
        GetComponent<Rigidbody>().velocity = velocity;

        if(time>= nextTime)
        {
            Destroy(gameObject);
        }
    }
}
