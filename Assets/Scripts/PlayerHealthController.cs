using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int maxHealth;
    public int currentHealth;

    private float _iFramesLength = 0.3f;
    private float _iFramesCounter;
   
    private void Awake()
    {
        instance = this;
    }
   
    
    void Start()
    {
        currentHealth = maxHealth;

        UIController.instance.healthSlider.maxValue = maxHealth;
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "" + currentHealth;
    }

    
    void Update()
    {
        if(_iFramesCounter > 0)
        {
            _iFramesCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if (_iFramesCounter <= 0)
        {
            _iFramesCounter = _iFramesLength;

            currentHealth -= damageAmount;

            UIController.instance.DamageIndicator();

            if (currentHealth <= 0)
            {
                currentHealth = 0;

                GameManager.instance.PlayerDeath();
                
                gameObject.SetActive(false);
            }

            AudioManager.instance.PlaySFX(0);

            UIController.instance.healthSlider.value = currentHealth;
            UIController.instance.healthText.text = "" + currentHealth;
        }
    }   
    
    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "" + currentHealth;
    }
}
