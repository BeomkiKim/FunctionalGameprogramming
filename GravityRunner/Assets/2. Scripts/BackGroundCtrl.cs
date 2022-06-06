using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCtrl : MonoBehaviour
{
    MeshRenderer meshRender;

    public Transform cameraTransform;

    public float speed;
    float offset;
    private void Awake()
    {
        Time.timeScale = 1;
        meshRender = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Vector3 backGround = new Vector3(cameraTransform.position.x, cameraTransform.position.y, 6);
        transform.position = backGround;

        offset += Time.deltaTime * speed;
        meshRender.material.mainTextureOffset = new Vector2(offset, 0);
    }

}
