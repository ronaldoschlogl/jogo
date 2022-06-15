using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IKillable
{
    public GameObject Jogador;
    public AudioClip SomZumbi;
    public AudioClip SomMorte;
    private Vector3 posicaoAleatoria;
    private Vector3 direcao;
    private Status statusEnemy;
    private float contadorVagar;
    private float tempoPosicaoAleatoria = 4;
    private MovimentoPersonagem movimentoInimigo;
    private AnimacaoPersonagem animacaoInimigo;



    void Start()
    {
        statusEnemy = GetComponent<Status>();
        movimentoInimigo = GetComponent<MovimentoPersonagem>();
        animacaoInimigo = GetComponent<AnimacaoPersonagem>();
        Jogador = GameObject.FindWithTag("Jogador");
        AleatorizarZumbi();
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        movimentoInimigo.Rotacionar(direcao);
        animacaoInimigo.Movimentar(direcao.magnitude);

        if (distancia > 15)
        {
            Vagar();

        }
        else if (distancia > 2.5)
        {
            direcao = Jogador.transform.position - transform.position;

            movimentoInimigo.Movimentar(direcao, statusEnemy.Velocidade);
            animacaoInimigo.Atacar(false);
        }
        else
        {
            direcao = Jogador.transform.position - transform.position;
            animacaoInimigo.Atacar(true);
        }
    }

    void Vagar()
    {
        contadorVagar -= Time.deltaTime;

        if(contadorVagar <= 0)
        {
            posicaoAleatoria = AleatorizarPosicao();
            contadorVagar += tempoPosicaoAleatoria;
        }

        bool ficouPerto = Vector3.Distance(transform.position, posicaoAleatoria) <= 0.05;

        if (ficouPerto == false)
        {
            direcao = posicaoAleatoria - transform.position;
            movimentoInimigo.Movimentar(direcao, statusEnemy.Velocidade);
        }
    }

    Vector3 AleatorizarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * 20;
        posicao += transform.position;
        posicao.y = transform.position.y;

        return posicao;
    }

    void AtacaJogador()
    {
        int dano = Random.Range(10, 30);
        Jogador.GetComponent<TPS>().TomarDano(dano);
        ControlaAudio.instancia.PlayOneShot(SomZumbi);
    }

    public void TomarDano(int dano)
    {
        statusEnemy.Vida -= dano;
        if(statusEnemy.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        Destroy(gameObject);
        ControlaAudio.instancia.PlayOneShot(SomMorte);
    }

    void AleatorizarZumbi()
    {
        int geraTipoZumbi = Random.Range(1, 30);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }
}
