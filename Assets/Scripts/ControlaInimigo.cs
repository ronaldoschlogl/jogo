using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;
    public AudioClip SomZumbi;


    void Start()
    {
        Jogador = GameObject.FindWithTag("Jogador");
        int geraTipoZumbi = Random.Range(1, 30);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        Vector3 direcao = Jogador.transform.position - transform.position;

        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                direcao.normalized * Velocidade * Time.deltaTime);
            
            GetComponent<Animator>().SetBool("Atacando", false);
        }
        else
        {
            GetComponent<Animator>().SetBool("Atacando", true);
        }
    }

    void AtacaJogador()
    {
        int dano = Random.Range(10, 30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
        ControlaAudio.instancia.PlayOneShot(SomZumbi);
    }
}
