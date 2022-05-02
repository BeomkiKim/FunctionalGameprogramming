using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    void Update()
    {
        transform.Translate(new Vector3(3.0f * Time.deltaTime, 0.0f, 0.0f));
    }
}
