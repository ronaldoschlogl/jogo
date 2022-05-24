using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCompanion : MonoBehaviour {
    public GameObject Jogador;
    public float Velocidade = 3;


    void Start()
    {

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

        if (distancia > 1.5)
        {
            GetComponent<Rigidbody>().MovePosition
                (GetComponent<Rigidbody>().position +
                direcao.normalized * Velocidade * Time.deltaTime);
        }
    }
}
