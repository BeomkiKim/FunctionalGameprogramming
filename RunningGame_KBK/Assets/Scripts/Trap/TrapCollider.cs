using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCollider : MonoBehaviour
{
    PlayerState player;

    private void Start()
    {
        player = FindObjectOfType<PlayerState>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            player.SendMessage("damage");
            Destroy(gameObject);
        }
    }
}
