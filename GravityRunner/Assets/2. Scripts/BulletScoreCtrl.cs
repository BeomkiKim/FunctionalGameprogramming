using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScoreCtrl : MonoBehaviour
{
    Text bulletScore;
    GameManager gameManager;
    float score;

    private void Start()
    {
        bulletScore = GetComponent<Text>();
        gameManager = GameObject.Find("GameRoot").GetComponent<GameManager>();
    }

    private void Update()
    {

        if (gameManager.gameTime < 240)
        {
            score = 400;
        }
        if (gameManager.gameTime >= 240 && gameManager.gameTime < 420)
        {
            score = 600;
        }
        if (gameManager.gameTime >= 420)
        {
            score = 800;
        }
    }
    public void HuntMonster()
    {
        Color color = bulletScore.color;
        color.a = 1;
        bulletScore.color = color;
        bulletScore.text = "+" + score.ToString();
        StartCoroutine(AutoActive());

    }
    IEnumerator AutoActive()
    {
        yield return new WaitForSeconds(0.5f);
        Color color = bulletScore.color;
        color.a = 0;
        bulletScore.color = color;
    }
}
