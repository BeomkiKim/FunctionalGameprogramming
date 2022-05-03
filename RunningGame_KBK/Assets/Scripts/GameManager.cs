using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float clearTime;
    public float gameTime;
    public GameObject clearUi;

    PlayerControl player;

    public float totalScore;
    public float timeScore;
    public float groundScore;

    public Text scoreText;
    public Text timeText;
    float sec, min;


    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        timeText.text = "00:00";
    }
    void sumScore()
    {
        totalScore = (timeScore*100) + (groundScore*200);
        scoreText.text = string.Format("{0:0}", totalScore);
    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        timeScore += Time.deltaTime;
        sec += Time.deltaTime;

        float secFloor = Mathf.Floor(sec);
        if(secFloor == 60)
        {
            sec = 0;
            min++;
        }
        timeText.text = min.ToString("00") + ":" + secFloor.ToString("00");
        if(player.isGround)
        {
            groundScore += Time.deltaTime;
        }
        if(gameTime >= clearTime)
        {
            sumScore();
            clearUi.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
