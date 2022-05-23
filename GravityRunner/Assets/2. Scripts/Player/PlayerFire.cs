using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFire : MonoBehaviour
{
    public GameObject bullet;
    public int bulletCount;
    public GameObject[] bulletImage;

    public AudioSource gunSound;
    public AudioClip bulletSound;
    private void Awake()
    {
        bulletCount = 0;
        bullet = Resources.Load("Bullet") as GameObject;
    }

    private void Update()
    {

        if(Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject() && Time.timeScale != 0 && bulletCount<=4)
        {
            GameObject shoot = GameObject.Instantiate(bullet, gameObject.transform.position, bullet.transform.rotation) as GameObject;
            bulletCount += 1;
            ShootSound();

        }
        if(bulletCount<0)
        {
            bulletCount = 0;
        }
        switch(bulletCount)
        {
            case 0:
                bulletImage[4].SetActive(true);
                bulletImage[3].SetActive(true);
                bulletImage[2].SetActive(true);
                bulletImage[1].SetActive(true);
                bulletImage[0].SetActive(true);
                break;
            case 1:
                bulletImage[0].SetActive(true);
                bulletImage[1].SetActive(true);
                bulletImage[2].SetActive(true);
                bulletImage[3].SetActive(true);
                bulletImage[4].SetActive(false);
                break;
            case 2:
                bulletImage[0].SetActive(true);
                bulletImage[1].SetActive(true);
                bulletImage[2].SetActive(true);
                bulletImage[3].SetActive(false);
                bulletImage[4].SetActive(false);
                break;
            case 3:
                bulletImage[0].SetActive(true);
                bulletImage[1].SetActive(true);
                bulletImage[2].SetActive(false);
                bulletImage[3].SetActive(false);
                bulletImage[4].SetActive(false);
                break;
            case 4:
                bulletImage[0].SetActive(true);
                bulletImage[1].SetActive(false);
                bulletImage[2].SetActive(false);
                bulletImage[3].SetActive(false);
                bulletImage[4].SetActive(false);
                break;
            case 5:
                bulletImage[0].SetActive(false);
                bulletImage[1].SetActive(false);
                bulletImage[2].SetActive(false);
                bulletImage[3].SetActive(false);
                bulletImage[4].SetActive(false);
                break;

        }
    }

    public void ShootSound()
    {
        gunSound.PlayOneShot(bulletSound);
    }
}
