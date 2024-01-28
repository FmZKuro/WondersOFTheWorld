using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectControler : MonoBehaviour
{
    public static SoundEffectControler instance { get; private set; }       // Instância única da classe, acessível de qualquer lugar no código
    public GameObject soundEffect;                                          // Prefab do efeito sonoro (AudioSource) que será instanciado para reproduzir os sons


    private void Awake()
    {
        if (instance != null && instance != this)                           // Garante que só haja uma instância única do SoundEffectController
        {
            Destroy(this);                                                  // Destroi esta instância se outra já existir
        }
        else
        {
            instance = this;                                                // Torna esta instância a instância única
            DontDestroyOnLoad(this.gameObject);                             // Impede que o GameObject seja destruído ao carregar novas cenas
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método para reproduzir um efeito sonoro com parâmetros personalizáveis
    public void playSound(AudioClip currAudio, float volumeAudio = 1.0f, float pitchAudio = 1.0f, bool isLooping = false)
    {
        if (currAudio == null)                                              // Verifica se o AudioClip é válido
        {
            return;                                                         // Sai do método se o AudioClip for nulo
        }

                                                                            // Instancia um novo objeto (AudioSource) para reproduzir o efeito sonoro
        GameObject audioSource = Instantiate(soundEffect, transform.position, transform.rotation);
        if (audioSource.GetComponent<ControlEffect>() != null)              // Verifica se o objeto instanciado tem um componente ControlEffect associado
        {
            // Chama o método playAudio do componente ControlEffect para iniciar a reprodução do áudio
            audioSource.GetComponent<ControlEffect>().playAudio(currAudio, volumeAudio, pitchAudio, isLooping);
        }
    }
}
