using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextSpawner : MonoBehaviour
{
    Text text;
    float time = 0;
    float fadeTime = 2.5f;


    public Text levelText;
    public int level = 1;


    private void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine("FadeStart");
    }

    IEnumerator FadeStart()
    {
        //level1

        time = 0;
        Color alpha = text.color;
        levelText.text = "★ 무 한 모 드 ★".ToString();
        yield return new WaitForSeconds(1.0f);
        while (alpha.a >0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        time = 0;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }


        //level2
        time = 0;
        yield return new WaitForSeconds(50f);
        level = 2;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a<1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }



        //level3
        time = 0;
        yield return new WaitForSeconds(54f);
        level = 3;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }



        //level4
        time = 0;
        yield return new WaitForSeconds(54f);
        level = 4;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }

        //level5
        time = 0;
        yield return new WaitForSeconds(54.0f);
        level = 5;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }

        time = 0;
        yield return new WaitForSeconds(0.3f);
        levelText.text = "지금부터 점수가 1.5배가 됩니다".ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }



        //level6
        time = 0;
        yield return new WaitForSeconds(52.7f);
        level = 6;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }
        //level7
        time = 0;
        yield return new WaitForSeconds(54f);
        level = 7;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }



        //level8
        time = 0;
        yield return new WaitForSeconds(54f);
        level = 8;
        
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(0.3f);
        levelText.text = "지금부터 점수가 2배가 됩니다.".ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }



        //level9
        time = 0;
        yield return new WaitForSeconds(52.7f);
        level = 9;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(1.0f);
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            text.color = alpha;
            yield return null;
        }



        //level10
        time = 0;
        yield return new WaitForSeconds(54f);
        level = 10;
        levelText.text = "LEVEL " + level.ToString();
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            text.color = alpha;
            yield return null;
        }
        time = 0;
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
