using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;
    Vector3 offset = Vector3.zero;

    private void Awake()
    {
        Screen.SetResolution(960, 540, false);
    }
    private void Start()
    {
        
        offset = transform.position - player.transform.position;

    }

    private void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = player.transform.position.x + offset.x;
        transform.position = newPosition;
    }
}
