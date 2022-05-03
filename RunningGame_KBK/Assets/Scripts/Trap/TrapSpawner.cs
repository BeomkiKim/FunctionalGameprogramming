using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    GameObject player = null;
    Vector3 positionOffset = Vector3.zero;
    public GameObject trap = null;

    float minDelay;
    float maxDelay;
    float time;
    int waitingTime;
    float realTime;
    int level;
    bool isFirst = false;
    bool isCoroutine = false;

    private void Start()
    {
        level = 1;
        time = 0.0f;
        waitingTime = 10;
        minDelay = 4;
        maxDelay = 6;
        player = GameObject.FindGameObjectWithTag("Player");
        positionOffset = transform.position - player.transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;
        realTime += Time.deltaTime;
        if(realTime > 10.0f) { minDelay = 4.0f; maxDelay = 8.0f; }
        if(realTime > 20.0f) { minDelay = 4.0f; maxDelay = 7.0f; }
        if(realTime > 30.0f) { minDelay = 3.5f; maxDelay = 6.0f; }
        if(realTime > 40.0f) { level = 2; minDelay = 2.5f; maxDelay = 4.5f; }
        if(realTime > 50.0f) { level = 3; minDelay = 2.0f; maxDelay = 4.0f; }

        float delay = Random.Range(minDelay, maxDelay);

        if(time > waitingTime && !isFirst)
        {
            Instantiate(trap, transform.position, transform.rotation);
            time = 0;
            isFirst = true;

        }
        if(time > delay && isFirst && !isCoroutine)
        {
            float random = Random.Range(0, level);
            int intRandom = (int)random;
            if (intRandom == 0)
                Instantiate(trap, transform.position, transform.rotation);
            if (intRandom == 1)
                StartCoroutine(DoubleTrap());
            if (intRandom == 2)
                StartCoroutine(TripleTrap());
            time = 0;

        }

        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + positionOffset.x;
        transform.position = newPosition;
    }

    IEnumerator DoubleTrap()
    {
        isCoroutine = true;
        Instantiate(trap, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(1.0f);
        isCoroutine = false;
    }
    IEnumerator TripleTrap()
    {
        isCoroutine = true;
        Instantiate(trap, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(0.5f);
        Instantiate(trap, this.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(1.0f);
        isCoroutine = false;
    }
}
