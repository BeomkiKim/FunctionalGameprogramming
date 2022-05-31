using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    public GameObject text;
    public GameObject text2;
    public float textSpeed;

    private void OnEnable()
    {
        StartCoroutine(Ending());
    }
    void Update()
    {
        if (Input.anyKey)
        {
            clickSkip();
        }
        text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y + textSpeed, text.transform.position.z);
        text2.transform.position = new Vector3(text2.transform.position.x, text2.transform.position.y + textSpeed, text2.transform.position.z);
        if (text2.transform.position.y >= 300)
            textSpeed = 0;
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(46.0f);
        clickSkip();
    }
    void clickSkip()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
