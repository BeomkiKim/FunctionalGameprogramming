using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public Button[] stage;

    private void Awake()
    {
        Screen.SetResolution(960, 540, false);
    }

    private void Start()
    {
        

        int stageAt = PlayerPrefs.GetInt("levelAt", 2);

        for(int i = 0; i<stage.Length; i++)
        {
            if(i+2>stageAt)
            {
                stage[i].interactable = false;
            }
        }
    }

}
