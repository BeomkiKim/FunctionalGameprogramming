using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryBGM : MonoBehaviour
{
    public GameObject audioBGM;
    // Start is called before the first frame update
    void Start()
    {
        audioBGM = GameObject.FindGameObjectWithTag("BGM");

        if (audioBGM == null) { return; }
        Destroy(audioBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
