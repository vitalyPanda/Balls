using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] audios;
    private AudioSource _a;

    private void Start()
    {
        _a = GetComponent<AudioSource>();
    }
    public void PlayHit()
    {
        _a.PlayOneShot(audios[0]);
    }

    public void PlayBonus()
    {
        _a.PlayOneShot(audios[1]);
    }

    public void Lose()
    {
        _a.PlayOneShot(audios[2]);
    }


}
