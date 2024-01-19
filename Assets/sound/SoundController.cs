using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundController : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    [SerializeField] public GameObject ambiente;
    [SerializeField] public GameObject musica;
    [SerializeField] public GameObject efeito;

    void Start()
    {
        
        // Configurar o valor inicial do slider com o volume atual
        volumeSlider.value = audioSource.volume;

        // Adicionar um ouvinte para o evento de valor alterado do slider
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    void ChangeVolume(float volume)
    {
        // Alterar o volume do AudioSource com base no valor do slider
        audioSource.volume = volume;
    }



    

   
}
