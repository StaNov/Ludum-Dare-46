using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer _instance;

    public AudioClip[] foodPlops;

    private AudioSource _kachon;
    private AudioSource _kytara;
    private AudioSource _kazoo;
    private AudioSource _effects;


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
        _effects = audioSources[3];
        

        foreach (var audioSource in audioSources)
        {
            audioSource.Play();
        }
    }

    public void PlayFoodPlop()
    {
        _effects.PlayOneShot(foodPlops[Random.Range(0, foodPlops.Length - 1)]);
    }
}
