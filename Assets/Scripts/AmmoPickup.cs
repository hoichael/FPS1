using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private bool _collected;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !_collected)
        {
            AudioManager.instance.PlaySFX(2);

            PlayerController.instance._activeGun.GetAmmo();
            _collected = true;
            Destroy(gameObject);
        }
    }

}
