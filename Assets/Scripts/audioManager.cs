using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip music;
    public AudioSource source;

    public void StartGame()
    {
        source.clip = music;
        source.Play();
    }

    public void StopGame()
    {
        source.Stop();
    }
}