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
    public float highScore;
    public float timeScore;
    public float groundScore;
    public int itemScore;
    public int monsterScore;

    public Text scoreText;
    public Text updateScoreText;
    public Text failScoreText;
    public Text timeText;
    public Text highScoreText;
    float sec, min;


    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        highScoreText.text = "High : "+ ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        timeText.text = "00:00";
    }
    public void sumScore()
    {
        totalScore = (timeScore*100) + (groundScore*200) + (itemScore*300) + (monsterScore * 400);
       
    }
    public void saveScore()
    {
        if(PlayerPrefs.GetFloat("Highscore")<totalScore)
            PlayerPrefs.SetFloat("Highscore", totalScore);

    }
    public void failGame()
    {
        sumScore();
        failScoreText.text = string.Format("{0:0}", totalScore);
        saveScore();

    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        timeScore += Time.deltaTime;
        sec += Time.deltaTime;

        sumScore();
        updateScoreText.text = string.Format("{0:0}", totalScore);
        

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
            scoreText.text = string.Format("{0:0}", totalScore);
            clearUi.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
