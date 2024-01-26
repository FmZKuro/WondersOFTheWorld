using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class camera : MonoBehaviour
{
    public Transform jogador;                                                   // Referência ao objeto do jogador
    public float offsetY = 1.3f;                                                // Offset na posição Y da câmera
    public float followSpeed = 2.0f;                                            // Velocidade da camera


    void Update()
    {                                                                           // Calcula a nova posição da câmera com base na posição do Player e no offset em Y
        Vector3 newPosition = new Vector3(jogador.position.x, jogador.position.y + offsetY, -10f);

        Vector3 velocity = Vector3.zero;                                        // Inicializa a velocidade como zero
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}

    /*void Update()
    {
        if (jogador != null)
        {
            // Obtém a posição atual do jogador
            Vector3 posicaoJogador = jogador.position;

            // Ajusta a posição Y da câmera
            posicaoJogador.y += offsetY;

            // Mantém a mesma posição Z da câmera
            posicaoJogador.z = transform.position.z;

            // Define a posição da câmera para a posição ajustada
            transform.position = posicaoJogador;
        }
    }
}


/* public Transform jogador; // Referência ao objeto do jogador
    public float offsetY = 1.3f; // Offset na posição Y da câmera
    public float suavizacao = 5.0f; // Fator de suavização

    void Update()
    {
        if (jogador != null)
        {
            // Obtém a posição atual do jogador
            Vector3 posicaoJogador = jogador.position;

            // Ajusta a posição Y da câmera
            posicaoJogador.y += offsetY;

            // Mantém a mesma posição Z da câmera
            posicaoJogador.z = transform.position.z;

            // Aplica a interpolação suave (lerp) para suavizar o movimento da câmera
            transform.position = Vector3.Lerp(transform.position, posicaoJogador, suavizacao * Time.deltaTime);
        }
    }*/