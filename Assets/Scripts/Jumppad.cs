using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumppad : MonoBehaviour
{
    public float jumpForce;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.PlaySFX(1);
            PlayerController.instance.JumpPad(jumpForce);
        }
    }
}
