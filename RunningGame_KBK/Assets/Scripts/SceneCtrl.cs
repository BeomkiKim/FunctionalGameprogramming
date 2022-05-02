using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{
    public void clickPlay()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    public void clickStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void clickStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void clickStage3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void clickMain()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
