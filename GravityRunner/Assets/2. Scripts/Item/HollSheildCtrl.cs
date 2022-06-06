using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollSheildCtrl : MonoBehaviour
{
    [SerializeField]
    public Material yellowMaterial;
    public Material newMaterial;
    public bool isStart;
    Renderer render;

    PlayerState player;

    private void OnEnable()
    {
        render = GetComponent<Renderer>();
        player = GameObject.Find("Player").GetComponent<PlayerState>();
        render.material = yellowMaterial;
        isStart = false;
    }
    private void Update()
    {
        if (player.hollsheildTime < 2.4f && !isStart && player.hollsheildTime > 0.0f)
        {
            StartCoroutine(MaterialChange());
            isStart = true;
        }
    }
    IEnumerator MaterialChange()
    {
        render.material = newMaterial;
        yield return new WaitForSeconds(0.3f);
        render.material = yellowMaterial;
        yield return new WaitForSeconds(0.3f);
        render.material = newMaterial;
        yield return new WaitForSeconds(0.3f);
        render.material = yellowMaterial;
        yield return new WaitForSeconds(0.3f);
        render.material = newMaterial;
        yield return new WaitForSeconds(0.3f);
        render.material = yellowMaterial;
        yield return new WaitForSeconds(0.3f);
        render.material = newMaterial;
        yield return new WaitForSeconds(0.3f);
        render.material = yellowMaterial;
        isStart = false;

        
    }
}
