using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerTwo controller = other.GetComponent<PlayerTwo>();
        UiRecord.instance.SetValue(controller.timer);
        Debug.Log(controller.timer);
        SceneManager.LoadScene("MainScene");
    }

}
