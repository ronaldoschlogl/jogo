using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    private AudioSource _audioSource;
    public static AudioSource instancia;

    void Awake ()
    {
        _audioSource = GetComponent<AudioSource>();
        instancia = _audioSource;
    }
}
