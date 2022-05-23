using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCredit : MonoBehaviour
{
    public GameObject text;
    public float textSpeed;

    private void Start()
    {
        StartCoroutine(Ending());
    }
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("TitleScene");
        }
        text.transform.position = new Vector3(text.transform.position.x, text.transform.position.y + textSpeed, text.transform.position.z);
    }

    IEnumerator Ending()
    {
        yield return new WaitForSeconds(30.0f);
        clickSkip();
    }
    void clickSkip()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
