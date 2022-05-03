using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    public float stepTimer = 0.0f;

    private void Update()
    {
        stepTimer += Time.deltaTime;
    }

    public float getPlayTime()
    {
        float time;
        time = stepTimer;
        return (time);
    }
}
