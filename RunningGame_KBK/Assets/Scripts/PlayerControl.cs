using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject FailUi;
    public float currentSpeed = 0.0f;
    public LevelControl levelControl = null;
    public bool isGround = false;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Dead")
        {
            Time.timeScale = 0;
            FailUi.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ground")
        {
            isGround = true;
        }
    }
    void Update()
    {
        isGround = false;
        currentSpeed = levelControl.getPlayerSpeed();
        transform.Translate(new Vector3(currentSpeed * Time.deltaTime, 0.0f, 0.0f));
        
        if(transform.position.y>10 || transform.position.y<-6)
        {
            Time.timeScale = 0;
            FailUi.SetActive(true);
        }
    }
}
