using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevelDemo : MonoBehaviour
{
    public int nextScene;

    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
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
}
