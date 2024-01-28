using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevadica : MonoBehaviour
{
    public float velocidade = 2f;                                               // Velocidade do movimento
    public GameObject posicaoInicialYObj;                                       // Objeto representando a posição inicial no eixo Y
    public GameObject posicaoFinalYObj;                                         // Objeto representando a posição final no eixo Y

    private bool indoParaCima = true;                                           // Flag indicando se o movimento está indo para cima

    void Update()
    {
        MoverNoEixoY();                                                         // Chama a função de movimento no eixo Y
    }

    void MoverNoEixoY()                                                         // Função para mover o objeto no eixo Y entre as posições inicial e final
    {
        float movimentoY = velocidade * Time.deltaTime;                         // Calcula o movimento baseado na velocidade e no tempo

        float posicaoInicialY = posicaoInicialYObj.transform.position.y;        // Obtém a posição inicial no eixo Y
        float posicaoFinalY = posicaoFinalYObj.transform.position.y;            // Obtém a posição final no eixo Y

        if (indoParaCima)
        {
            transform.Translate(Vector3.up * movimentoY);                       // Move para cima

            if (transform.position.y >= posicaoFinalY)                          // Verifica se atingiu ou ultrapassou a posição final
            {
                indoParaCima = false;                                           // Inverte a direção para descer
            }
        }
        else
        {
            transform.Translate(Vector3.down * movimentoY);                     // Move para baixo

            if (transform.position.y <= posicaoInicialY)                        // Verifica se atingiu ou ultrapassou a posição inicial
            {
                indoParaCima = true;                                            // Inverte a direção para subir
            }
        }
    }
}
