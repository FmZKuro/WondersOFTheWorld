using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectControler : MonoBehaviour
{
    public static SoundEffectControler instance { get; private set;}
    public GameObject soundEffect;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
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

    public void playSound(AudioClip currAudio, float volumeAudio = 1.0f, float pitchAudio = 1.0f, bool isLooping = false)
    {
        if (currAudio == null)
        {
            return;
        }

        GameObject audioSource = Instantiate(soundEffect, transform.position, transform.rotation);
        if (audioSource.GetComponent<ControlEffect>() != null)
        {
            audioSource.GetComponent<ControlEffect>().playAudio(currAudio, volumeAudio, pitchAudio, isLooping);
        }
    }
}
