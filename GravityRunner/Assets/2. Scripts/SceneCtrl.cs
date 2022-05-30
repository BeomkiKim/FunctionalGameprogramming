using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    public GameObject stage1Obejct;
    public GameObject stage2Obejct;

    public void Awake()
    {
        if (stage1Obejct == null)
            return;
        if (stage2Obejct == null)
            return;
    }
    public void clickPlay()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void clickStage1Easy()
    {
        SceneManager.LoadScene("Stage1Easy");
    }
    public void clickStage1Hard()
    {
        SceneManager.LoadScene("Stage1Hard");
    }
    public void clickStage2Easy()
    {
        SceneManager.LoadScene("Stage2Easy");
    }
    public void clickStage2Hard()
    {
        SceneManager.LoadScene("Stage2Hard");
    }
    public void clickStage3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void clickMain()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void clickEnding()
    {
        SceneManager.LoadScene("Ending");
    }


    public void clickStage1()
    {
        stage1Obejct.SetActive(true);
    }
    public void clickStage2()
    {
        stage2Obejct.SetActive(true);
    }
    public void click1X()
    {
        stage1Obejct.SetActive(false);
    }
    public void click2X()
    {
        stage2Obejct.SetActive(false);
    }
}
