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

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
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
