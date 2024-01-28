using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectControler : MonoBehaviour
{
    public static SoundEffectControler instance { get; private set; }       // Inst�ncia �nica da classe, acess�vel de qualquer lugar no c�digo
    public GameObject soundEffect;                                          // Prefab do efeito sonoro (AudioSource) que ser� instanciado para reproduzir os sons


    private void Awake()
    {
        if (instance != null && instance != this)                           // Garante que s� haja uma inst�ncia �nica do SoundEffectController
        {
            Destroy(this);                                                  // Destroi esta inst�ncia se outra j� existir
        }
        else
        {
            instance = this;                                                // Torna esta inst�ncia a inst�ncia �nica
            DontDestroyOnLoad(this.gameObject);                             // Impede que o GameObject seja destru�do ao carregar novas cenas
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

    // M�todo para reproduzir um efeito sonoro com par�metros personaliz�veis
    public void playSound(AudioClip currAudio, float volumeAudio = 1.0f, float pitchAudio = 1.0f, bool isLooping = false)
    {
        if (currAudio == null)                                              // Verifica se o AudioClip � v�lido
        {
            return;                                                         // Sai do m�todo se o AudioClip for nulo
        }

                                                                            // Instancia um novo objeto (AudioSource) para reproduzir o efeito sonoro
        GameObject audioSource = Instantiate(soundEffect, transform.position, transform.rotation);
        if (audioSource.GetComponent<ControlEffect>() != null)              // Verifica se o objeto instanciado tem um componente ControlEffect associado
        {
            // Chama o m�todo playAudio do componente ControlEffect para iniciar a reprodu��o do �udio
            audioSource.GetComponent<ControlEffect>().playAudio(currAudio, volumeAudio, pitchAudio, isLooping);
        }
    }
}
