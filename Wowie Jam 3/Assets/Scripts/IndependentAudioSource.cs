using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndependentAudioSource : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    private bool startedPlaying = true;

    private void Update()
    {
        if(startedPlaying)
        {
            if(!audioSource.isPlaying)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void Play(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.pitch = pitch;
        audioSource.Play();
        startedPlaying = true;
    }
}
