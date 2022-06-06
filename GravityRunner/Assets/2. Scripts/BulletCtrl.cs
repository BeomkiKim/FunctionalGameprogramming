using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    //public float bulletSpeed;
    GameManager game;
    PlayerFire player;
    public float speed;
    public Transform playerTransform;

    SphereCollider bulletCollider;

    private void OnEnable()
    {
        game = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerFire>();
        playerTransform = GameObject.Find("Player").transform;
        bulletCollider = GetComponent<SphereCollider>();
        StartCoroutine(DestroyBullet());

    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        if (transform.position.x - playerTransform.position.x > 9)
        {
            bulletCollider.enabled = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Monster":
                BulletScoreCtrl bulletScore = GameObject.Find("BulletScore").GetComponent<BulletScoreCtrl>();
                bulletScore.HuntMonster();
                game.monsterScore += 1;
                other.SendMessage("Dead");
                player.bulletCount -= 1;
                Destroy(gameObject);
                break;
        }
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(3.5f);
        player.bulletCount -= 1;
        Destroy(gameObject);
    }
}
