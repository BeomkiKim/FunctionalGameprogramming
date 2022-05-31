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
    public GameObject[] count;
    public AudioSource audioSource;
    public AudioClip pauseCountClip;



    private void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
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
        int currentLevel = SceneManager.GetActiveScene().buildIndex+1;

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
        StartCoroutine(PauseCount());
    }
    IEnumerator PauseCount()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(pauseCountClip);
        count[0].SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        count[0].SetActive(false);
        count[1].SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        count[1].SetActive(false);
        count[2].SetActive(true);
        yield return new WaitForSecondsRealtime(1.0f);
        count[2].SetActive(false);
        count[3].SetActive(true);
        yield return new WaitForSecondsRealtime(0.5f);
        count[3].SetActive(false);
        Time.timeScale = 1;


    }
}
