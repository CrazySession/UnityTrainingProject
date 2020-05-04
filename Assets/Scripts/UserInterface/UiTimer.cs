using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTimer : MonoBehaviour
{

    Text timer;
    float startTime = 15.0f;

    private void Awake()
    {
        timer = GetComponent<Text>();
    }

    void Update()
    {
        startTime = startTime - Time.deltaTime;
        timer.text = startTime.ToString("#.00");
        Debug.Log(timer.text);
    }
}
