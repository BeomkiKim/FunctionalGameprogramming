using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMaterial : MonoBehaviour
{
    private Renderer playerRenderer;
    public Material playerMaterial;

    public Material sheildMaterial;
    public bool isSheilding;
    public Material heartMaterial;
    public bool isHearting;
    public Material hollMaterial;
    public bool isHolling;
    public Material damageMaterial;
    public bool isDamaging;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originMaterial();
        isSheilding = false;
        isHearting = false;
        isHolling = false;
        isDamaging = false;
    }
    private void Update()
    {
        if (!isSheilding && !isHearting && !isHolling && !isDamaging)
            originMaterial();
        if (!isSheilding && !isHearting && !isHolling && isDamaging)
            changeDamageMaterial();
        if (!isSheilding && isHearting && !isHolling && !isDamaging)
            changeHeartMaterial();
        if (isSheilding && !isHearting && !isHolling && !isDamaging)
            changeSheildMaterial();
        if (!isSheilding && !isHearting && isHolling && !isDamaging)
            changeHollMaterial();
        if (!isSheilding && !isHearting && isHolling && isDamaging)
            changeDamageMaterial();
        if(!isSheilding && isHearting && isHolling && !isDamaging)
            changeHeartMaterial();
        if(isSheilding && isHearting && !isHolling && !isDamaging)
            changeSheildMaterial();
        if(isSheilding && !isHearting && isHolling && !isDamaging)
            changeSheildMaterial();
        if(isSheilding && isHearting && isHolling && !isDamaging)
            changeSheildMaterial();
    }
    public void originMaterial()
    {
        playerRenderer.material = playerMaterial;
    }
    public void changeSheildMaterial()
    {
        playerRenderer.material = sheildMaterial;
    }
    public void changeHeartMaterial()
    {
        playerRenderer.material = heartMaterial;
        StartCoroutine(HeartToOrigin());
    }
    IEnumerator HeartToOrigin()
    {
        yield return new WaitForSeconds(0.5f);
        isHearting = false;
    }
    public void changeHollMaterial()
    {
        playerRenderer.material = hollMaterial;
    }
    public void changeDamageMaterial()
    {
        playerRenderer.material = damageMaterial;
        StartCoroutine(DamageToOrigin());
    }
    IEnumerator DamageToOrigin()
    {
        yield return new WaitForSeconds(0.5f);
        isDamaging = false;
    }
}
