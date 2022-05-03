using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerFire : MonoBehaviour
{
    public float bulletPower;
    public GameObject[] bulletPool;
    public GameObject[] bulletImage;
    int poolSize = 5;

    private void Start()
    {
        bulletPool = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(Resources.Load("Bullet")) as GameObject;
            bulletPool[i] = bullet;
            

            bullet.SetActive(false);
            bulletImage[i].SetActive(true);
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject() && Time.timeScale != 0)
        {
            for(int i = 0; i< poolSize; i++)
            {
                GameObject bullet = bulletPool[i];
                GameObject image = bulletImage[i];

                if(!bullet.activeSelf)
                {
                    bullet.SetActive(true);
                    image.SetActive(false);
                    bullet.transform.position = transform.position + new Vector3(1.0f, 0, 0);

                    bullet.GetComponent<Rigidbody>().AddForce(Vector2.right * bulletPower, ForceMode.Impulse);

                    StartCoroutine(ResetBullet(bullet));
                    StartCoroutine(ResetImage(image));
                    break;
                }
            }
        }
    }

    IEnumerator ResetBullet(GameObject bullet)
    {
        yield return new WaitForSeconds(2);

        bullet.SetActive(false);
    }
    IEnumerator ResetImage(GameObject image)
    {
        yield return new WaitForSeconds(2);
        image.SetActive(true);
    }
}
