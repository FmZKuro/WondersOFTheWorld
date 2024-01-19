using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevadica : MonoBehaviour
{
    public float velocidade = 2f; // Velocidade do movimento
    public GameObject posicaoInicialYObj; // Objeto representando a posi��o inicial no eixo Y
    public GameObject posicaoFinalYObj; // Objeto representando a posi��o final no eixo Y

    private bool indoParaCima = true;

    void Update()
    {
        MoverNoEixoY();
    }

    void MoverNoEixoY()
    {
        float movimentoY = velocidade * Time.deltaTime;

        float posicaoInicialY = posicaoInicialYObj.transform.position.y;
        float posicaoFinalY = posicaoFinalYObj.transform.position.y;

        if (indoParaCima)
        {
            transform.Translate(Vector3.up * movimentoY);

            if (transform.position.y >= posicaoFinalY)
            {
                indoParaCima = false;
            }
        }
        else
        {
            transform.Translate(Vector3.down * movimentoY);

            if (transform.position.y <= posicaoInicialY)
            {
                indoParaCima = true;
            }
        }
    }
}
