using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGravity : MonoBehaviour
{
    Rigidbody rigid;
    public float gravity = 1200f;
    public AudioSource switchSound;
    public AudioClip gravitySound;



    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rigid.AddForce(0.0f, -gravity * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravity *= -1;
            SwitchGravitySound();
        }
    }
    public void SwitchGravitySound()
    {
        switchSound.PlayOneShot(gravitySound);
    }
}
