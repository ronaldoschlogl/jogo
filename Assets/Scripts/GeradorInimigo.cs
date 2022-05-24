using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorInimigo : MonoBehaviour
{
    public GameObject Zumbi;
    public GameObject Kiki;
    public GameObject UnityChan;
    public GameObject Arisa;
    float contadorTempo = 0;
    public float TempoGerarZumbi = 50;
    int rInt = 0;


    // Update is called once per frame
    void Update()
    {
        //int rnd = Random.Range(0,2);
        int rnd = 1;

        contadorTempo += (Time.deltaTime / 2);

        if (contadorTempo >= TempoGerarZumbi)
        {
            if (rnd == 1)
            {
                Instantiate(Zumbi, transform.position, transform.rotation);
            }
           

            contadorTempo = 0;
        }

    }
}
