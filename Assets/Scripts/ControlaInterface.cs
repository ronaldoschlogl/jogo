using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    private ControlaJogador scripControlaJogador;
    public Slider SliderVidaJogador;
    // Start is called before the first frame update
    void Start()
    {
        scripControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scripControlaJogador.Vida;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scripControlaJogador.Vida;
    }
}
