using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    public enum ItemKind
    {
        Heart,
        Sheild,
        Empty,
    };

    public ItemKind kind;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerState player = other.GetComponent<PlayerState>();
            player.GetItem(kind);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(-3.0f * Time.deltaTime, 0.0f, 0.0f));
    }
}
