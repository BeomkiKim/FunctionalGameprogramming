using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevelDemo : MonoBehaviour
{
    public int nextScene;
    public GameObject pauseImage;

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
        }
    }

    public void Pass()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;

        if (currentLevel >= PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", currentLevel + 1);
        }
        //SceneManager.LoadScene("LevelSelect");
    }
    public void timePlay()
    {
        Time.timeScale = 1;
        pauseImage.SetActive(false);
    }
}
