using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage1TextSpawner : MonoBehaviour
{
    public enum StageLevel
    {
        EASY,
        HARD,
    }
    public StageLevel stageLevel;
    Text text;
    float time = 0;
    float fadeTime = 2.5f;


    public Text levelText;

    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine("FadeStart");
    }

    IEnumerator FadeStart()
    {
        time = 0;
        Color alpha = text.color;
        levelText.text = stageLevel+"모드\n50초를 버텨라!".ToString();
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }
    }
}
