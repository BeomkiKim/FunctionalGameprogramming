using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject howToPlay;
    public GameObject[] howtoPlayCtrl;
    public GameObject option;
    public GameObject resetOption;
    public bool isOption = false;
    bool isHowToPlay = false;
    bool isResetOption = false;

    private void Awake()
    {
        Screen.SetResolution(960, 540, false);
    }
    public void clickNextPage()
    {
        howtoPlayCtrl[0].SetActive(false);
        howtoPlayCtrl[1].SetActive(true);

    }
    public void clickBackPage()
    {
        howtoPlayCtrl[0].SetActive(true);
        howtoPlayCtrl[1].SetActive(false);
    }
    public void clickHowtoPlay()
    {
        howToPlay.SetActive(true);
        isHowToPlay = true;

    }

    public void clickHtPX()
    {
        howToPlay.SetActive(false);
        isHowToPlay = false;
    }
    public void clickOption()
    {
        option.SetActive(true);
        isOption = true;
    }
    public void clickOptionX()
    {
        option.SetActive(false);
        isOption = false;
    }
    public void clickNo()
    {
        resetOption.SetActive(false);
        isResetOption = false;
    }
    public void clickReset()
    {
        resetOption.SetActive(true);
        isResetOption = true;
    }
    public void clickYes()
    {
        PlayerPrefs.DeleteAll();
        option.SetActive(false);
        resetOption.SetActive(false);
        isResetOption = false;
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
        //if(isHowToPlay && Input.GetKeyDown(KeyCode.Escape))
        //{
        //    howToPlay.SetActive(false);
        //    isHowToPlay = false;
        //}
        //if(isOption &&  Input.GetKeyDown(KeyCode.Escape))
        //{
        //    option.SetActive(false);
        //    isOption = false;
        //}
    }
}
