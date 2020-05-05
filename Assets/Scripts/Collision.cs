using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public AudioClip collectedClip;

    public void OnCollisionEnter2D(Collision2D other)
    {
        PlayerTwo player = other.gameObject.GetComponent<PlayerTwo>();

        if(player != null)
        {
            player.changeHealth(-1);
            player.PlaySound(collectedClip);
        }
    
    }
}
