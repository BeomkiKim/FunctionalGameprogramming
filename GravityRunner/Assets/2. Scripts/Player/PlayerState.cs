using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    [HideInInspector]
    public int life;
    [HideInInspector]
    public int lifeCur;
    [HideInInspector]
    public float sheildTime = 0.0f;
    [HideInInspector]
    public float maxSheildTime = 5.0f;

    [HideInInspector]
    public float hollsheildTime = 0.0f;
    [HideInInspector]
    public float maxhollSheildTime = 5.0f;



    public GameObject heartUI;
    public GameObject[] heart;
    public GameObject sheildImage;
    public GameObject hollSheild;
    public GameObject hollSheildUI;
    public Image sheildBar;
    public Image hollSheildBar;
    [HideInInspector]
    public int heartCount;

    public GameObject failUi;

    GameManager game;
    PlayerControl player;
    PlayerMaterial playerMaterial;



    public AudioSource audioSource;
    public AudioClip itemClip;
    public AudioClip damageClip;
    private void Start()
    {
        game = FindObjectOfType<GameManager>();
        player = GetComponent<PlayerControl>();
        playerMaterial = GetComponent<PlayerMaterial>();
        lifeCur = life;
        heartCount = life - 1;
    }
    void damage()
    {
        if(sheildTime<=0)
        {
            lifeCur -= 1;
            heart[heartCount].SetActive(false);
            playerMaterial.isDamaging = true;
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(damageClip);
            heartCount -= 1;
        }

    }

    public void GetItem(ItemCtrl.ItemKind kind)
    {
        switch(kind)
        {
            case ItemCtrl.ItemKind.Heart:
                game.itemScore += 2;
                game.itemRealCount += 1;
                if (!audioSource.isPlaying)
                    audioSource.PlayOneShot(itemClip);
                if (lifeCur < 3)
                {
                    lifeCur += 1;
                    heartCount += 1;
                    playerMaterial.isHearting = true;
                    heart[heartCount].SetActive(true);
                }
                break;
            case ItemCtrl.ItemKind.Sheild:
                sheildImage.SetActive(true);
                if(!audioSource.isPlaying)
                    audioSource.PlayOneShot(itemClip);
                game.itemScore += 1;
                game.itemRealCount += 1;
                playerMaterial.isSheilding = true;
                sheildTime += 5.0f;
                break;
            case ItemCtrl.ItemKind.Holl:
                hollSheild.SetActive(true);
                hollSheildUI.SetActive(true);
                if (!audioSource.isPlaying)
                    audioSource.PlayOneShot(itemClip);
                hollsheildTime += 60.0f;
                game.itemScore += 3;
                game.itemRealCount += 1;
                break;
            case ItemCtrl.ItemKind.Empty:
                break;
        }
    }
    private void Update()
    {

        if (sheildTime > 0.0f)
        {
            sheildTime -= Time.deltaTime;
            sheildBar.fillAmount = sheildTime / maxSheildTime;
            heartUI.SetActive(false);
        }
        else
        {
            heartUI.SetActive(true);
        }

        if(hollsheildTime > 0.0f)
        {
            hollsheildTime -= Time.deltaTime;
            playerMaterial.isHolling = true;
            hollSheildBar.fillAmount = hollsheildTime / maxhollSheildTime;
        }
        if(hollsheildTime<=0.0f)
        {
            hollsheildTime = 0;
            playerMaterial.isHolling = false;
            hollSheild.SetActive(false);
            hollSheildUI.SetActive(false);
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
            playerMaterial.isSheilding = false;
            sheildImage.SetActive(false);
        }

        //플레이어죽음
        if(lifeCur <= 0)
        {
            player.Dead();

        }
    }

}
