using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider healthSlider;
    public Text healthText;

    public Text ammoText;

    public Image damageIndicator;
    public float damageAlpha = 0.4f;
    public float fadeSpeed = 0.8f;

    public Image blackScreen;
    public float bsFadeSpeed = 2f;

    private void Awake()
    {
        instance = this;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(damageIndicator.color.a != 0)
        {
            damageIndicator.color = new Color(damageIndicator.color.r, damageIndicator.color.g, damageIndicator.color.b, Mathf.MoveTowards(damageIndicator.color.a, 0f, fadeSpeed * Time.deltaTime));
        }

        if(!GameManager.instance.levelEnding)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, bsFadeSpeed * Time.deltaTime));
        }
        else
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, bsFadeSpeed * Time.deltaTime));
        }
    }

    public void DamageIndicator()
    {
        damageIndicator.color = new Color(damageIndicator.color.r, damageIndicator.color.g, damageIndicator.color.b, damageAlpha);
    }
}
