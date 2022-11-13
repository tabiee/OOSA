using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambience : MonoBehaviour
{
    public AudioClip[] soundtrack;
    public AudioSource ears;
    public void Awake()
    {
        //loads all audioclips in the folder Audio (regardless of what subfolder they are in)
        var loadAudioSources = Resources.LoadAll<AudioClip>("Music/");
        soundtrack = loadAudioSources;
    }
    void Update()
    {
        if (!ears.isPlaying)
        {
            ears.clip = soundtrack[Random.Range(0, soundtrack.Length)];
            ears.Play();
        }
    }
}
