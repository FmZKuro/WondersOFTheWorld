using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Vector2 sizeTiled;                                      // Tamanho inicial da barra de vida em um sistema de tiles
    private Slider sliderRef;                                       // Referência ao componente Slider associado à barra de vida

    private void Awake()
    {
        sliderRef = GetComponent<Slider>();                         // Obtém o componente Slider na inicialização
        sizeTiled = GetComponent<RectTransform>().sizeDelta;        // Obtém o tamanho inicial da barra de vida em um sistema de tiles
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void setHealthTiled(int health)                         // Função para ajustar o tamanho da barra de vida em um sistema de tiles
    {
        GetComponent<RectTransform>().sizeDelta = new Vector2(sizeTiled.x * health, sizeTiled.y);
    }

    private void setHealthSlider(int health)                        // Função para ajustar o valor da barra de vida em um componente Slider
    {
        if (sliderRef != null)
        {
            sliderRef.value = (float)health;                        // Ajusta o valor do Slider para a quantidade de saúde
        }
    }

    public void setMaxHealth(int maxHealth)                         // Função para definir a quantidade máxima de saúde
    {
        if (sliderRef != null)
        {
            sliderRef.maxValue = (float)maxHealth;                  // Define o valor máximo do Slider
            sliderRef.value = (float)maxHealth;                     // Define o valor atual do Slider como a quantidade máxima de saúde
        }
        else
        {
            setHealthTiled(maxHealth);                              // Se não houver Slider, ajusta o tamanho da barra de vida em um sistema de tiles
        }
    }

    public void setHealth(int health)                               // Função para ajustar a quantidade atual de saúde
    {
        if (sliderRef != null)
        {
            setHealthSlider(health);                               // Se houver Slider, ajusta o valor do Slider
        }
        else
        {
            setHealthTiled(health);                                 // Se não houver Slider, ajusta o tamanho da barra de vida em um sistema de tiles
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
