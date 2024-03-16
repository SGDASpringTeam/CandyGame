using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SFXPlayer
{
    public static AudioSource PlayClip2D(AudioClip clip, float volume)
    {
        // Create our new AudioSource
        GameObject audioObject = new GameObject("2D Audio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();
        // Configure Clip to 2D
        audioSource.clip = clip;
        audioSource.volume = volume;

        audioSource.Play();
        // Destroy when done
        Object.Destroy(audioObject, clip.length);
        // return it
        return audioSource;
    }

}
