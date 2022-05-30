using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    public GameObject text;
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
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(50.0f);
        clickSkip();
    }
    void clickSkip()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
