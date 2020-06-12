using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    public int healAmount;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioManager.instance.PlaySFX(3);

            PlayerHealthController.instance.HealPlayer(healAmount);

            Destroy(gameObject);
        }
    }
}
