using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundController : MonoBehaviour
{
    public Slider volumeSlider;                                         // Refer�ncia ao Slider que controla o volume   
    public AudioSource audioSource;                                     // Refer�ncia ao componente AudioSource a ser controlado
    [SerializeField] public GameObject ambiente;                        // Objeto do ambiente, exemplo: som ambiente

    void Start()
    {
        volumeSlider.value = audioSource.volume;                        // Configura o valor inicial do slider com o volume atual do AudioSource
        volumeSlider.onValueChanged.AddListener(ChangeVolume);          // Adiciona um ouvinte para o evento de valor alterado do slider
    }

    void ChangeVolume(float value)                                     // M�todo chamado quando o valor do slider � alterado
    {        
        audioSource.volume = value;                                    // Alterar o volume do AudioSource com base no valor do slider
    }   
}
