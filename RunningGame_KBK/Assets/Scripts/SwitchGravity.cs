using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    Rigidbody rigid;
    public float gravity = 1000f;


    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigid.AddForce(0.0f, -gravity * Time.deltaTime, 0);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            gravity *= -1;
        }
    }
}
