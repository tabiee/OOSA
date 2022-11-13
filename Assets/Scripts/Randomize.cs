using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Randomize : MonoBehaviour
{
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    public void Awake()
    {
        //loads all audioclips in the folder Audio (regardless of what subfolder they are in)
        var loadAudioSources = Resources.LoadAll<AudioClip>("Audio/");
        audioSources = loadAudioSources;
    }
    public void PlaySound()
    {
        gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        Invoke("Randomizer", 0);
    }
    void Randomizer()
    {
        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        randomSound.Play();
    }
    public void Repeater()
    {
        InvokeRepeating("Randomizer", 0.0f, 6.0f);
    }
}
