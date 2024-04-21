using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MusicSource; // The audio source component.
    public AudioClip bgMusic; // The audio clip to be played.

    void Start() {
        MusicSource.clip = bgMusic; // Set the audio clip to be played.
        MusicSource.Play(); // Play the audio clip.
    }
}
