using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject FailUi;
    public float currentSpeed = 0.0f;
    public LevelControl levelControl = null;
    public bool isGround = false;
    GameManager game;

    private void Start()
    {
        Time.timeScale = 1;
        game = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //플레이어죽음
        if(other.tag == "Dead")
        {
            Dead();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            isGround = true;
        }
    }
    public void Dead()
    {
        game.failGame();

        Time.timeScale = 0;
        FailUi.SetActive(true);
    }
    void Update()
    {
        isGround = false;
        currentSpeed = levelControl.getPlayerSpeed();
        transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0.0f, 0.0f));
        
        //플레이어죽음
        if(transform.position.y>10 || transform.position.y<-6)
        {
            Dead();
        }
    }
}
