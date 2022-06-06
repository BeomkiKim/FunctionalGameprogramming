using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public enum ItemKind
    {
        Heart,
        Sheild,
        Holl,
        Empty,
    };

    public ItemKind kind;
    float destroyTime;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerState player = other.GetComponent<PlayerState>();
            ItemScoreCtrl itemScore = GameObject.Find("ItemScore").GetComponent<ItemScoreCtrl>();
            itemScore.getItem(kind);
            player.GetItem(kind);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        destroyTime += Time.deltaTime;
        transform.Translate(new Vector3(-3.0f * Time.deltaTime, 0.0f, 0.0f));
        if (destroyTime >= 10f)
            Destroy(gameObject);
    }
}
