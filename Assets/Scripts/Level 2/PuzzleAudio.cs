using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleAudio : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip audio;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        audioSource.clip = audio;
        audioSource.Play();
    }

    private void OnDisable()
    {
        audioSource.Stop();
    }
}
