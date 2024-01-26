using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEffect : MonoBehaviour
{

    private AudioSource currSource;

    private void Awake()
    {
        currSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!currSource.isPlaying)
        {
            Destroy(gameObject);
        }
    }

    public void playAudio (AudioClip currAudio, float volumeAudio, float pitchAudio = 1.0f, bool isLooping = false)
    {
        currSource.clip = currAudio;
        currSource.volume = volumeAudio;
        currSource.pitch = pitchAudio;
        currSource.loop = isLooping;
        currSource.Play();
    }
}
