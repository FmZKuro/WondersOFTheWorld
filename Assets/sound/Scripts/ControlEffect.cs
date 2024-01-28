using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEffect : MonoBehaviour
{
    private AudioSource currSource;                     // Referência ao componente AudioSource associado a este GameObject

    private void Awake()
    {
        currSource = GetComponent<AudioSource>();       // Obtém o componente AudioSource associado a este GameObject
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!currSource.isPlaying)                      // Verifica se o áudio atual não está mais tocando
        {
            Destroy(gameObject);                        // Destroi este GameObject quando o áudio termina de tocar
        }
    }

    // Método para reproduzir um áudio com parâmetros personalizáveis
    public void playAudio (AudioClip currAudio, float volumeAudio, float pitchAudio = 1.0f, bool isLooping = false)
    {
        currSource.clip = currAudio;                    // Define o AudioClip que será reproduzido
        currSource.volume = volumeAudio;                // Define o volume do áudio
        currSource.pitch = pitchAudio;                  // Define o pitch (tom) do áudio
        currSource.loop = isLooping;                    // Define se o áudio deve ser reproduzido em loop
        currSource.Play();                              // Inicia a reprodução do áudio
    }
}
