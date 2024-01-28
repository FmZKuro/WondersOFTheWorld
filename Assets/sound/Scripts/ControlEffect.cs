using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEffect : MonoBehaviour
{
    private AudioSource currSource;                     // Refer�ncia ao componente AudioSource associado a este GameObject

    private void Awake()
    {
        currSource = GetComponent<AudioSource>();       // Obt�m o componente AudioSource associado a este GameObject
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!currSource.isPlaying)                      // Verifica se o �udio atual n�o est� mais tocando
        {
            Destroy(gameObject);                        // Destroi este GameObject quando o �udio termina de tocar
        }
    }

    // M�todo para reproduzir um �udio com par�metros personaliz�veis
    public void playAudio (AudioClip currAudio, float volumeAudio, float pitchAudio = 1.0f, bool isLooping = false)
    {
        currSource.clip = currAudio;                    // Define o AudioClip que ser� reproduzido
        currSource.volume = volumeAudio;                // Define o volume do �udio
        currSource.pitch = pitchAudio;                  // Define o pitch (tom) do �udio
        currSource.loop = isLooping;                    // Define se o �udio deve ser reproduzido em loop
        currSource.Play();                              // Inicia a reprodu��o do �udio
    }
}
