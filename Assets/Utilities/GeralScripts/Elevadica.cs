using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevadica : MonoBehaviour
{
    public float velocidade = 2f;                                               // Velocidade do movimento
    public GameObject posicaoInicialYObj;                                       // Objeto representando a posi��o inicial no eixo Y
    public GameObject posicaoFinalYObj;                                         // Objeto representando a posi��o final no eixo Y

    private bool indoParaCima = true;                                           // Flag indicando se o movimento est� indo para cima

    void Update()
    {
        MoverNoEixoY();                                                         // Chama a fun��o de movimento no eixo Y
    }

    void MoverNoEixoY()                                                         // Fun��o para mover o objeto no eixo Y entre as posi��es inicial e final
    {
        float movimentoY = velocidade * Time.deltaTime;                         // Calcula o movimento baseado na velocidade e no tempo

        float posicaoInicialY = posicaoInicialYObj.transform.position.y;        // Obt�m a posi��o inicial no eixo Y
        float posicaoFinalY = posicaoFinalYObj.transform.position.y;            // Obt�m a posi��o final no eixo Y

        if (indoParaCima)
        {
            transform.Translate(Vector3.up * movimentoY);                       // Move para cima

            if (transform.position.y >= posicaoFinalY)                          // Verifica se atingiu ou ultrapassou a posi��o final
            {
                indoParaCima = false;                                           // Inverte a dire��o para descer
            }
        }
        else
        {
            transform.Translate(Vector3.down * movimentoY);                     // Move para baixo

            if (transform.position.y <= posicaoInicialY)                        // Verifica se atingiu ou ultrapassou a posi��o inicial
            {
                indoParaCima = true;                                            // Inverte a dire��o para subir
            }
        }
    }
}
