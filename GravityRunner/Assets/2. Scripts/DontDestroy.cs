using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject dontDestroy;

    private void Start()
    {
        DontDestroyOnLoad(dontDestroy);

        GameObject[] audios = GameObject.FindGameObjectsWithTag("BGM");

        if (audios.Length >= 2)
        {
            Destroy(audios[1]);
        }
    }

    //public GameObject audioBGM;
    //private void Start()
    //{
    //    audioBGM = GameObject.FindGameObjectWithTag("BGM");
    //    if (audioBGM == null) { return; }
    //    Destroy(this.audioBGM);
    //}
}
