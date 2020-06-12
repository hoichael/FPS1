using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string gunName;

    private bool _collected;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !_collected)
        {
            AudioManager.instance.PlaySFX(4);

            PlayerController.instance.AddGun(gunName);
            _collected = true;
            Destroy(gameObject);
        }
    }
}
