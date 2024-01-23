using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Vector2 sizeTiled;                                      // Tamanho inicial da barra de vida em um sistema de tiles
    private Slider sliderRef;                                       // Refer�ncia ao componente Slider associado � barra de vida

    private void Awake()
    {
        sliderRef = GetComponent<Slider>();                         // Obt�m o componente Slider na inicializa��o
        sizeTiled = GetComponent<RectTransform>().sizeDelta;        // Obt�m o tamanho inicial da barra de vida em um sistema de tiles
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void setHealthTiled(int health)                         // Fun��o para ajustar o tamanho da barra de vida em um sistema de tiles
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(sizeTiled.x * health, sizeTiled.y);
    }

    private void setHealthSlider(int health)                        // Fun��o para ajustar o valor da barra de vida em um componente Slider
    {
        if (sliderRef != null)
        {
            sliderRef.value = (float)health;                        // Ajusta o valor do Slider para a quantidade de sa�de
        }
    }

    public void setMaxHealth(int maxHealth)                         // Fun��o para definir a quantidade m�xima de sa�de
    {
        if (sliderRef != null)
        {
            sliderRef.maxValue = (float)maxHealth;                  // Define o valor m�ximo do Slider
            sliderRef.value = (float)maxHealth;                     // Define o valor atual do Slider como a quantidade m�xima de sa�de
        }
        else
        {
            setHealthTiled(maxHealth);                              // Se n�o houver Slider, ajusta o tamanho da barra de vida em um sistema de tiles
        }
    }

    public void setHealth(int health)                               // Fun��o para ajustar a quantidade atual de sa�de
    {
        if (sliderRef != null)
        {
            setHealthSlider(health);                               // Se houver Slider, ajusta o valor do Slider
        }
        else
        {
            setHealthTiled(health);                                 // Se n�o houver Slider, ajusta o tamanho da barra de vida em um sistema de tiles
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
