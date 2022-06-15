using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour
{
    private TPS scripControlaJogador;
    public Slider SliderVidaJogador;
    public GameObject PainelGameOver;
    public Text TextoTempoSobrevivencia;

    void Start()
    {
        scripControlaJogador = GameObject.FindWithTag("Jogador").GetComponent<TPS>();
        SliderVidaJogador.maxValue = scripControlaJogador.statusPlayer.Vida;
        AtualizarSliderVidaJogador();
        Time.timeScale = 1;
    }
    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scripControlaJogador.statusPlayer.Vida;
    }

    public void GameOver()
    {
        int minutos = (int)(Time.timeSinceLevelLoad / 60);
        int segundos = (int)(Time.timeSinceLevelLoad % 60);
        TextoTempoSobrevivencia.text = "Voce sobreviveu por " + minutos + "min e " + segundos + "s.";
        Time.timeScale = 0;
        PainelGameOver.SetActive(true);

        
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("game");
    }


}
