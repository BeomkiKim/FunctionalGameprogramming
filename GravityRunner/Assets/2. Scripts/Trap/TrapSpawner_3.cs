using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpawner_3 : MonoBehaviour
{
    GameObject player = null;
    Vector3 positionOffset = Vector3.zero;
    public GameObject trap = null;

    float minDelay;
    float maxDelay;
    public float time;
    int waitingTime;
    public float realTime;

    public int level;
    bool isFirst = false;
    bool isCoroutine = false;

    private void Start()
    {
        level = 1;
        time = 0.0f;
        waitingTime = 25;
        minDelay = 4;
        maxDelay = 6;
        player = GameObject.FindGameObjectWithTag("Player");
        positionOffset = transform.position - player.transform.position;
    }

    private void Update()
    {
        time += Time.deltaTime;
        realTime += Time.deltaTime;
        if (realTime > 10.0f) { minDelay = 5.75f; maxDelay = 8.9f; }
        if (realTime > 20.0f) { minDelay = 5.25f; maxDelay = 7.9f; }
        if (realTime > 30.0f) { level = 2; minDelay = 4.75f; maxDelay = 6.9f; }
        if (realTime > 40.0f) { minDelay = 4.25f; maxDelay = 5.9f; }
        if (realTime > 50.0f) { level = 3; minDelay = 3.75f; maxDelay = 4.9f; }
        if (realTime > 60.0f) { level = 1; realTime = 0.0f; isFirst = false; }

        float delay = Random.Range(minDelay, maxDelay);

        if(time > waitingTime && !isFirst)
        {
            Instantiate(trap, transform.position, transform.rotation);
            time = 0;
            isFirst = true;

        }
        if(time > delay && isFirst && !isCoroutine && realTime > 10.0f)
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
