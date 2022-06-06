using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public Slider volumSlider;
    public GameObject[] soundImage;
    ButtonCtrl button;
    PassLevelDemo pass;

    private void Awake()
    {
        button = GetComponent<ButtonCtrl>();
        pass = GetComponent<PassLevelDemo>();
        if (button == null)
            return;
        if (pass == null)
            return;
    }
    private void OnEnable()
    {


        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 0.5f);
            save();
        }
        else
        {
            load();
        }
    }
    private void Update()
    {
        if (button != null && pass == null)
        {
            if (volumSlider.value <= 0 && button.isOption)
            {
                soundImage[0].SetActive(false);
                soundImage[1].SetActive(true);
            }
            if (volumSlider.value > 0 && button.isOption)
            {
                soundImage[0].SetActive(true);
                soundImage[1].SetActive(false);
            }
        }
        if(button == null && pass != null)
        {
            if (volumSlider.value == 0 && pass.isPause)
            {
                soundImage[0].SetActive(false);
                soundImage[1].SetActive(true);
            }
            if (volumSlider.value > 0 && pass.isPause)
            {
                soundImage[0].SetActive(true);
                soundImage[1].SetActive(false);
            }
        }
    }

    public void setVolum()
    {
        AudioListener.volume = volumSlider.value;
        save();
    }
    void load()
    {
        volumSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }
    void save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumSlider.value);
    }

}
