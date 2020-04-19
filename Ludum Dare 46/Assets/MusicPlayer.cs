using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer _instance;

    private AudioSource _kachon;
    private AudioSource _kytara;
    private AudioSource _kazoo;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        _kachon = audioSources[0];
        _kytara = audioSources[1];
        _kazoo = audioSources[2];

        foreach (var audioSource in audioSources)
        {
            audioSource.Play();
        }
    }
}
