using System.Collections;
using System.Timers;
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
    public int itemRealCount;
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

    [Header("切室備")]
    public Text groundTime;
    public Text groundTimeScore;
    public Text itemCount;
    public Text itemCountScore;
    public Text enemyCount;
    public Text enemyCountScore;

    public float isGround;
    public float isItem;
    public float isEnemy;


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
        if (gameTime < 240)
        {
            isGround = groundScore * 200;
            isItem = itemScore * 500;
            isEnemy = monsterScore * 400;
            totalScore = (timeScore * 100) + isGround + isItem + isEnemy;
            
        }
        if (gameTime >= 240 && gameTime < 480)
        {
            isGround = groundScore * 300;
            isItem = itemScore * 750;
            isEnemy = monsterScore * 600;
            totalScore = (timeScore * 150) + isGround + isItem + isEnemy;
            
        }
        if (gameTime >= 420)
        {
            isGround = groundScore * 400;
            isItem = itemScore * 1000;
            isEnemy = monsterScore * 800;
            totalScore = (timeScore * 200) + isGround + isItem + isEnemy;
            
        }
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

        groundTime.text = groundScore.ToString("00.00") + "段";
        groundTimeScore.text = isGround.ToString("00");
        itemCount.text = itemRealCount.ToString();
        itemCountScore.text = isItem.ToString();
        enemyCount.text = monsterScore.ToString();
        enemyCountScore.text = isEnemy.ToString();

        
        if (levelText != null)
        {
            levelText.text = levelTextSpawner.level.ToString();
        }
        switch (stage)
        {
            case Stage.End:
                failScoreText.text = string.Format("{0:0}", totalScore);
                finishTimeText.text = min.ToString("00") + ":" + clearTime.ToString("00");

                groundTime.text = groundScore.ToString("00.00") + "段";
                groundTimeScore.text = isGround.ToString("00");
                itemCount.text = itemRealCount.ToString();
                itemCountScore.text = isItem.ToString();
                enemyCount.text = monsterScore.ToString();
                enemyCountScore.text = isEnemy.ToString();
                if (!audioSource.isPlaying)
                audioSource.PlayOneShot(fail);
                break;
            case Stage.EndLess:
                failScoreText.text = string.Format("{0:0}", totalScore);
                finishTimeText.text = min.ToString("00") + ":" + secFloor.ToString("00");

                groundTime.text = groundScore.ToString("00.00") + "段";
                groundTimeScore.text = isGround.ToString("00");
                itemCount.text = itemRealCount.ToString();
                itemCountScore.text = isItem.ToString();
                enemyCount.text = monsterScore.ToString();
                enemyCountScore.text = isEnemy.ToString();
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
        if (player.isGround)
        {

            groundScore += Time.deltaTime;
        }
        switch (stage)
        {
            case Stage.End:
                gameTime += Time.deltaTime;
                timeScore += Time.deltaTime;

                clearTime -= Time.deltaTime;
                if (Time.timeScale != 0)
                    sumScore();
                updateScoreText.text = string.Format("{0:0}", totalScore);

                timeText.text = min.ToString("00") + ":" + clearTime.ToString("00");

                if (clearTime<= 0)
                {
                    sumScore();
                    saveScore();
                    scoreText.text = string.Format("{0:0}", totalScore);
                    clearTimeText.text = min.ToString("00") + ":" + gameTime.ToString("00");

                    groundTime.text = groundScore.ToString("00.00") + "段";
                    groundTimeScore.text = isGround.ToString("00");
                    itemCount.text = itemRealCount.ToString();
                    itemCountScore.text = isItem.ToString();
                    enemyCount.text = monsterScore.ToString();
                    enemyCountScore.text = isEnemy.ToString();

                    clearUi.SetActive(true);
                    if (!audioSource.isPlaying)
                        audioSource.PlayOneShot(clear);
                    Time.timeScale = 0;
                }
                break;
            case Stage.EndLess:
                gameTime += Time.deltaTime;
                timeScore += Time.deltaTime;
                sec += Time.deltaTime;
                if (Time.timeScale != 0)
                    sumScore();
                updateScoreText.text = string.Format("{0:0}", totalScore);


                secFloor = Mathf.Floor(sec);
                if (secFloor == 60)
                {
                    sec = 0;
                    min++;
                }
                timeText.text = min.ToString("00") + ":" + secFloor.ToString("00");

                if (gameTime >= clearTime)
                {
                    sumScore();
                    saveScore();
                    scoreText.text = string.Format("{0:0}", totalScore);
                    clearTimeText.text = min.ToString("00") + ":" + secFloor.ToString("00");

                    groundTime.text = groundScore.ToString("00.00") + "段";
                    groundTimeScore.text = isGround.ToString("00");
                    itemCount.text = itemRealCount.ToString();
                    itemCountScore.text = isItem.ToString();
                    enemyCount.text = monsterScore.ToString();
                    enemyCountScore.text = isEnemy.ToString();

                    clearUi.SetActive(true);
                    if (!audioSource.isPlaying)
                        audioSource.PlayOneShot(clear);
                    Time.timeScale = 0;
                }
                break;
        }

    }
}
