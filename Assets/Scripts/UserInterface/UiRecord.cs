using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiRecord : MonoBehaviour
{
    public static UiRecord instance { get; private set; }

    Text record;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        record = GetComponent<Text>();
    }

    public void SetValue(float currentRecord)
    {
        record.text = currentRecord.ToString("#.00");
        //Debug.Log(timer.text);
    }
}
