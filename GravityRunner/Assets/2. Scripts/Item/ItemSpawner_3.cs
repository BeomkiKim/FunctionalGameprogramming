using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner_3 : MonoBehaviour
{
    public int[] percentage =
    {
        50,
        30,
        20
    };
    [SerializeField]
    int total;

    GameObject player = null;
    Vector3 positionOffset = Vector3.zero;
    public GameObject[] itemPrefab;

    float minDelay;
    float maxDelay;
    float time;
    int waitingTime;
    float realTime;
    bool isFirst = false;

    private void Start()
    {
        time = 0.0f;
        waitingTime = 10;
        minDelay = 4;
        maxDelay = 6;
        player = GameObject.FindGameObjectWithTag("Player");
        positionOffset = transform.position - player.transform.position;
        foreach(var item in percentage)
            total += item;
    }
    void itemSpawn()
    {
        if (itemPrefab.Length == 0)
            return;
        else
        {
            int randomNumber = Random.Range(0, total);
            for(int i = 0; i<percentage.Length; i++)
            {
                if (randomNumber <= percentage[i])
                {
                    GameObject spawnItem = itemPrefab[i];
                    Instantiate(spawnItem, transform.position, Quaternion.identity);
                    return;
                }
                else
                    randomNumber -= percentage[i];
            }
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        realTime += Time.deltaTime;
        if (realTime > 10.0f) { minDelay = 8.0f; maxDelay = 16.0f; }
        if (realTime > 30.0f) { minDelay = 8.0f; maxDelay = 14.0f; }
        if (realTime > 50.0f) { minDelay = 7.0f; maxDelay = 12.0f; }
        if (realTime > 60.0f) { realTime = 0.0f; isFirst = false; }

        float delay = Random.Range(minDelay, maxDelay);

        if (time > waitingTime && !isFirst)
        {
            itemSpawn();
            time = 0;
            isFirst = true;

        }
        if (time > delay && isFirst && realTime > 10.0f)
        {

            itemSpawn();
            time = 0;

        }

        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + positionOffset.x;
        transform.position = newPosition;
    }


}
