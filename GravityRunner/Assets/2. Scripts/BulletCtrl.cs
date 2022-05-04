using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    //public float bulletSpeed;
    GameManager game;
    PlayerFire player;

    private void OnEnable()
    {
        game = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerFire>();
        StartCoroutine(DestroyBullet());

    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 50;
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Monster":
                Destroy(gameObject);
                game.monsterScore += 1;
                other.SendMessage("Dead");

                StartCoroutine(BulletCountCtrl());
                player.bulletCount -= 1;
                break;
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3);
        player.bulletCount -= 1;
        Destroy(gameObject);
    }
    IEnumerator BulletCountCtrl()
    {
        yield return new WaitForSeconds(3);
    }
}
