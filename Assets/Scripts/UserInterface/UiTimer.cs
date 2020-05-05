using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTimer : MonoBehaviour
{
    public static UiTimer instance { get; private set; }

    Text timer;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timer = GetComponent<Text>();
    }

    public void SetValue(float startTime)
    {
        timer.text = startTime.ToString("#.00");
        //Debug.Log(timer.text);
    }
}


