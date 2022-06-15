using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    public LayerMask MascaraChao;
    public GameObject GameOver;
    private Vector3 direcao;
    public ControlaInterface scriptControlaInterface;
    public AudioClip SomDano;


    public Status statusPlayer = new Status();

    void Start()
    {
        Time.timeScale = 1;
        statusPlayer = GetComponent<Status>();
    }

    void Update()
    {
        
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

         direcao = new Vector3(eixoX, 0, eixoZ);

        if(direcao != Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        if (statusPlayer.Vida <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");
            }
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition
            (GetComponent<Rigidbody>().position + (direcao * statusPlayer.Velocidade * Time.deltaTime) * -1);

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }

    public void TomarDano(int dano)
    {
        statusPlayer.Vida -= dano;
        scriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.instancia.PlayOneShot(SomDano);

        if (statusPlayer.Vida <= 0)
        {
            Time.timeScale = 0;
            GameOver.SetActive(true);
        }
        
    }
}
