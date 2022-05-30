using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtrl2 : MonoBehaviour
{
    Light theLight;



    private void OnEnable()
    {
        theLight = GetComponent<Light>();
        StartCoroutine(LightOnOff());

    }
    IEnumerator LightOnOff()
    {
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 120f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 120f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 120f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 120f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 120f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 0f;
        yield return new WaitForSeconds(0.5f);
        theLight.intensity = 120f;
    }
}
