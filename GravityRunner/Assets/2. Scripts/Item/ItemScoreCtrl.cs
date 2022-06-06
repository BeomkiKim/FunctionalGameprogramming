using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScoreCtrl : MonoBehaviour
{
    Text itemScore;
    GameManager gameManager;
    float score;

    float heartScore;
    float hollScore;
    float sheildScore;

    private void Start()
    {
        itemScore = GetComponent<Text>();
        gameManager = GameObject.Find("GameRoot").GetComponent<GameManager>();
    }
    private void Update()
    {
        
        if (gameManager.gameTime < 240)
        {
            score = 300;
        }
        if (gameManager.gameTime >= 240 && gameManager.gameTime < 420)
        {
            score = 450;
        }
        if (gameManager.gameTime >= 420)
        {
            score = 600;
        }  
    }
    public void getItem(ItemCtrl.ItemKind kind)
    {
        Color alpha = itemScore.color;
        alpha.a = 1;
        itemScore.color = alpha;

        switch (kind)
        {
            case ItemCtrl.ItemKind.Heart://2
                itemScore.color = Color.green;
                StartCoroutine(AutoActive());
                heartScore = 2 * score;
                itemScore.text = "+"+heartScore.ToString();
                break;
            case ItemCtrl.ItemKind.Sheild:
                itemScore.color = new Color(134, 0,255);
                StartCoroutine(AutoActive());
                sheildScore = score;
                //game.itemScore += 1;
                itemScore.text = "+" + sheildScore.ToString();
                break;
            case ItemCtrl.ItemKind.Holl:
                itemScore.color = new Color(255,244,0);
                StartCoroutine(AutoActive());
                hollScore = 3 * score;
                itemScore.text = "+" + hollScore.ToString();
                break;
            case ItemCtrl.ItemKind.Empty:
                break;
        }
    }

    IEnumerator AutoActive()
    {
        yield return new WaitForSeconds(0.5f);
        Color color = itemScore.color;
        color.a = 0;
        itemScore.color = color;
    }
}
