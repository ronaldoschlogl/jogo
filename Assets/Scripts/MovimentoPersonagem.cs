using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoPersonagem : MonoBehaviour
{
    private Rigidbody rigidBody;
    
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Movimentar(Vector3 Direcao, float Velocidade)
    {
        rigidBody.MovePosition
                (rigidBody.position +
                Direcao.normalized * Velocidade * Time.deltaTime);
    }

    public void Rotacionar(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidBody.MoveRotation(novaRotacao);
    }
}
