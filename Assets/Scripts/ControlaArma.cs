using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Bala;
    public GameObject CanoDaArma;
    public ParticleSystem Flash;
    public AudioClip SomTiro;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Flash.Play();
            ControlaAudio.instancia.PlayOneShot(SomTiro);

            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
        }
    }
}
