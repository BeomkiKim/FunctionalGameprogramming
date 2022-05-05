using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject howToPlay;
    public GameObject option;
    bool isOption = false;
    bool isHowToPlay = false;
    public void clickHowtoPlay()
    {
        howToPlay.SetActive(true);
        isHowToPlay = true;

    }
    public void clickOption()
    {
        option.SetActive(true);
        isOption = true;
    }
    public void clickReset()
    {
        PlayerPrefs.DeleteAll();
        option.SetActive(false);
        isOption = false;
    }
    public void clickQuit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void Update()
    {
        if(isHowToPlay && Input.GetKeyDown(KeyCode.Escape))
        {
            howToPlay.SetActive(false);
            isHowToPlay = false;
        }
        if(isOption &&  Input.GetKeyDown(KeyCode.Escape))
        {
            option.SetActive(false);
            isOption = false;
        }
    }
}
