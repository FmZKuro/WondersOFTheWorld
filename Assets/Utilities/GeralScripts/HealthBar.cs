using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Vector2 sizeTiled;
    private Slider sliderRef;

    private void Awake()
    {
        sliderRef = GetComponent<Slider>();
        sizeTiled = GetComponent<RectTransform>().sizeDelta;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void setHealthTiled(int health)
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(sizeTiled.x * health, sizeTiled.y);
    }

    private void setHealthSlider(int health)
    {
        if (sliderRef != null)
        {
            sliderRef.value = (float)health;
        }
    }

    public void setMaxHealth(int maxHealth)
    {
        if (sliderRef != null)
        {
            sliderRef.maxValue = (float)maxHealth;
            sliderRef.value = (float)maxHealth;
        }
        else
        {
            setHealthTiled(maxHealth);
        }
    }

    public void setHealth(int health)
    {
        if (sliderRef != null)
        {
            setHealthSlider(health);
        }
        else
        {
            setHealthTiled(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
