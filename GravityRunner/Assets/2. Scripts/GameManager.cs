using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Stage
    {
        End,
        EndLess,
    }

    public Stage stage;

    public float clearTime;
    public float gameTime;
    public GameObject clearUi;

    PlayerControl player;
    LevelTextSpawner levelTextSpawner;
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
    public Text finishTimeText;
    public Text clearTimeText;
    public Text highScoreText;
    public Text levelText;
    float sec, min;
    float secFloor;

    public AudioSource audioSource;
    public AudioClip clear;
    public AudioClip fail;

    private void Start()
    {
        player = FindObjectOfType<PlayerControl>();
        levelTextSpawner = FindObjectOfType<LevelTextSpawner>();
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
        highScoreText.text = "High : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
        if (clearUi == null) return;
        if (clearTimeText == null) return;
        if (levelText == null) return;

        timeText.text = "00:00";
        finishTimeText.text = "00:00";
        clearTimeText.text = "00:00";

    }
    public void sumScore()
    {
        if(gameTime<300)
            totalScore = (timeScore * 100) + (groundScore * 200) + (itemScore * 300) + (monsterScore * 400);
        if(gameTime>=300 && gameTime < 420)
            totalScore = (timeScore * 150) + (groundScore * 300) + (itemScore * 450) + (monsterScore * 600);
        if (gameTime >= 420)
            totalScore = (timeScore * 200) + (groundScore * 400) + (itemScore * 600) + (monsterScore * 800);
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
        finishTimeText.text = min.ToString("00") + ":" + secFloor.ToString("00");
        
        if (levelText != null)
        {
            levelText.text = levelTextSpawner.level.ToString();
        }
        switch (stage)
        {
            case Stage.End:
                if(!audioSource.isPlaying)
                audioSource.PlayOneShot(fail);
                break;
            case Stage.EndLess:
                if (PlayerPrefs.GetFloat("Highscore") < totalScore && !audioSource.isPlaying)
                    audioSource.PlayOneShot(clear);
                if(PlayerPrefs.GetFloat("Highscore") >= totalScore && !audioSource.isPlaying)
                    audioSource.PlayOneShot(fail);
                break;
        }

        saveScore();
        Time.timeScale = 0;

    }
    private void Update()
    {
        gameTime += Time.deltaTime;
        timeScore += Time.deltaTime;
        sec += Time.deltaTime;

        sumScore();
        updateScoreText.text = string.Format("{0:0}", totalScore);
        

        secFloor = Mathf.Floor(sec);
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
            saveScore();
            scoreText.text = string.Format("{0:0}", totalScore);
            clearTimeText.text = min.ToString("00") + ":" + secFloor.ToString("00");
            clearUi.SetActive(true);
            if(!audioSource.isPlaying)
                audioSource.PlayOneShot(clear);
            Time.timeScale = 0;
        }
    }
}
