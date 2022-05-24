using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassLevelDemo : MonoBehaviour
{
    public int nextScene;
    public GameObject pauseImage;
    public bool isPause = false;


    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseImage.SetActive(true);
            isPause = true;
        }
    }

    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", currentLevel);
        }
        //SceneManager.LoadScene("LevelSelect");
    }
    public void timePlay()
    {
        pauseImage.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }
}
