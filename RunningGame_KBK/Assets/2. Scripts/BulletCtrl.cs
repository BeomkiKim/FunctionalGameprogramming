using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    GameManager game;

    private void Start()
    {
        game = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Monster":
                gameObject.SetActive(false);
                game.monsterScore += 1;
                other.SendMessage("Dead");
                break;
        }
    }
}
