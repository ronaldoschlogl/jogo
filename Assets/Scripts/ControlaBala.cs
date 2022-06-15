using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    //public float Speed = 30;
    //public AudioClip SomMorte;

    //void FixedUpdate()
    //{
    //    GetComponent<Rigidbody>().MovePosition(
    //        GetComponent<Rigidbody>().position + transform.forward * Speed * Time.deltaTime * -1);
    //}

    //void OnTriggerEnter(Collider objetoDeColisao)
    //{
    //    if(objetoDeColisao.tag == "Inimigo")
    //    {
    //        Destroy(objetoDeColisao.gameObject);
    //        ControlaAudio.instancia.PlayOneShot(SomMorte);
    //    }

    //    Destroy(gameObject);
    //}

    public float speed = 25;
    public AudioClip SomMorte;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            collision.gameObject.GetComponent<ControlaInimigo>().TomarDano(1);
        }
        Destroy(gameObject);
    }
}
