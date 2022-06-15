using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigo : MonoBehaviour
{
    public GameObject Zumbi;
    float contadorTempo = 0;
    public float TempoGerarZumbi = 50;
    public LayerMask LayerZumbi;
    private float distanciaGeracao = 3;
    private float DistanciaDoJogadorParaGeracao = 20;
    private GameObject Jogador;

    private void Start() 
    {
        Jogador = GameObject.FindWithTag("Jogador");
    }

    void Update()
    {
        if(Vector3.Distance(transform.position, Jogador.transform.position) > DistanciaDoJogadorParaGeracao)
        {
            contadorTempo += (Time.deltaTime / 2);

            if (contadorTempo >= TempoGerarZumbi)
            {
                StartCoroutine(GerarNovoZumbi());
                contadorTempo = 0;
            }
        }
    }

    IEnumerator GerarNovoZumbi()
    {
        Vector3 posicaoDeCriacao = AleatorizarPosicao();
        Collider[] colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);

        while(colisores.Length > 0)
        {
            posicaoDeCriacao = AleatorizarPosicao();
            colisores = Physics.OverlapSphere(posicaoDeCriacao, 1, LayerZumbi);
            yield return null;
        }

        Instantiate(Zumbi, posicaoDeCriacao, transform.rotation);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanciaGeracao);
    }

    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * distanciaGeracao;
        posicao += transform.position;
        posicao.y = 0;

        return posicao;
    }
}
