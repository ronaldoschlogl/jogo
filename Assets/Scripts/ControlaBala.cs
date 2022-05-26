using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    public float Velocidade = 30;
    public AudioClip SomMorte;

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(
            GetComponent<Rigidbody>().position + transform.forward * Velocidade * Time.deltaTime * -1);
    }

    void OnTriggerEnter(Collider objetoDeColisao)
    {
        if(objetoDeColisao.tag == "Inimigo")
        {
            Destroy(objetoDeColisao.gameObject);
            ControlaAudio.instancia.PlayOneShot(SomMorte);
        }

        Destroy(gameObject);
    }
}
