using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordCtrl : MonoBehaviour
{
    public GameObject plusRecord;


    public void clickPlus()
    {
        plusRecord.SetActive(true);
    }
    public void clickX()
    {
        plusRecord.SetActive(false);
    }
}
