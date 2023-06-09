using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3Aud : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip audioClip;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private void OnDisable()
    {
        audioSource.Stop();
    }
}