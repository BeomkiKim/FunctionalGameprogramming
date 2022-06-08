using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCtrl : MonoBehaviour
{
    public GameObject howToPlay;
    public GameObject patch;
    public GameObject[] howtoPlayCtrl;
    public GameObject[] patchNote;
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
    public void clickPatchNote()
    {
        patch.SetActive(true);
    }
    public void clickPatchX()
    {
        patchNote[0].SetActive(true);
        patchNote[1].SetActive(false);
        patchNote[2].SetActive(false);
        patchNote[3].SetActive(false);
        patch.SetActive(false);
    }
    public void patchFirstToSecond()
    {
        patchNote[0].SetActive(false);
        patchNote[1].SetActive(true);

    }
    public void patchSecondToFirst()
    {
        patchNote[0].SetActive(true);
        patchNote[1].SetActive(false);

    }
    public void patchSecondToThird()
    {
        patchNote[1].SetActive(false);
        patchNote[2].SetActive(true);

    }
    public void patchThirdToSecond()
    {   
        patchNote[1].SetActive(true);
        patchNote[2].SetActive(false);

    }
    public void patchThirdToFourth()
    {
        patchNote[2].SetActive(false);
        patchNote[3].SetActive(true);

    }
    public void patchFourthToThird()
    {
        patchNote[3].SetActive(false);
        patchNote[2].SetActive(true);

    }

    public void clickHtPX()
    {
        howtoPlayCtrl[0].SetActive(true);
        howtoPlayCtrl[1].SetActive(false);
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
}
