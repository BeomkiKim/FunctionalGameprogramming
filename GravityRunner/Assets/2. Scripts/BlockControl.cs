using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockControl : MonoBehaviour
{
    public MapCreator mapCreator = null;
    public UpMapCreator upMap = null;


    private void Start()
    {
        mapCreator = GameObject.Find("GameRoot").GetComponent<MapCreator>();
        upMap = GameObject.Find("GameRoot").GetComponent<UpMapCreator>();

    }
    private void Update()
    {
        if(mapCreator.isDelete(gameObject))
        {
            GameObject.Destroy(gameObject);
        }
        if(upMap.isDelete(gameObject))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
