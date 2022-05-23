using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCtrl : MonoBehaviour
{
    MeshRenderer meshRender;
    public Material backGroundMaterial;

    public Transform cameraTransform;

    public float speed;
    float offset;
    private void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        Vector2 backGround = cameraTransform.position;
        transform.position = backGround;

        offset += Time.deltaTime * speed;
        meshRender.material.mainTextureOffset = new Vector2(offset, 0);
    }

}
