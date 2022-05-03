using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int life;
    public int lifeCur;
    public float sheildTime = 0.0f;


    public GameObject[] heart;
    public GameObject sheildImage;
    public int heartCount;

    public GameObject failUi;

    private void Start()
    {
        lifeCur = life;
        heartCount = life - 1;
    }
    void damage()
    {
        if(sheildTime<=0)
        {
            lifeCur -= 1;
            heart[heartCount].SetActive(false);
            heartCount -= 1;
        }

    }

    public void GetItem(ItemCtrl.ItemKind kind)
    {
        switch(kind)
        {
            case ItemCtrl.ItemKind.Heart:
                if (lifeCur < 3)
                {
                    lifeCur += 1;
                    heartCount += 1;
                    heart[heartCount].SetActive(true);
                }
                break;
            case ItemCtrl.ItemKind.Sheild:
                sheildImage.SetActive(true);
                sheildTime += 5.0f;
                break;
            case ItemCtrl.ItemKind.Empty:
                break;
        }
    }
    private void Update()
    {
        if(sheildTime > 0.0f)
        {
            sheildTime -= Time.deltaTime;
        }
        if(lifeCur >= 3)
        {
            lifeCur = 3;
        }
        if(heartCount >= 2)
        {
            heartCount = 2;
        }
        if(sheildTime<=0)
        {
            sheildTime = 0;
            sheildImage.SetActive(false);
        }

        if(lifeCur <= 0)
        {
            failUi.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
