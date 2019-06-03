using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicStart;
    public AudioClip musicLoop;

    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(musicStart);
        
    }

    private void Update()
    {
        if (!source.isPlaying) {
            source.clip = musicLoop;
            GetComponent<AudioSource>().Play();
        }
       
    }
}
