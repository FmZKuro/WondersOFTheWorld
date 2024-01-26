using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class camera : MonoBehaviour
{
    public Transform jogador;                                                   // Refer�ncia ao objeto do jogador
    public float offsetY = 1.3f;                                                // Offset na posi��o Y da c�mera
    public float followSpeed = 2.0f;                                            // Velocidade da camera


    void Update()
    {                                                                           // Calcula a nova posi��o da c�mera com base na posi��o do Player e no offset em Y
        Vector3 newPosition = new Vector3(jogador.position.x, jogador.position.y + offsetY, -10f);

        Vector3 velocity = Vector3.zero;                                        // Inicializa a velocidade como zero
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}

    /*void Update()
    {
        if (jogador != null)
        {
            // Obt�m a posi��o atual do jogador
            Vector3 posicaoJogador = jogador.position;

            // Ajusta a posi��o Y da c�mera
            posicaoJogador.y += offsetY;

            // Mant�m a mesma posi��o Z da c�mera
            posicaoJogador.z = transform.position.z;

            // Define a posi��o da c�mera para a posi��o ajustada
            transform.position = posicaoJogador;
        }
    }
}


/* public Transform jogador; // Refer�ncia ao objeto do jogador
    public float offsetY = 1.3f; // Offset na posi��o Y da c�mera
    public float suavizacao = 5.0f; // Fator de suaviza��o

    void Update()
    {
        if (jogador != null)
        {
            // Obt�m a posi��o atual do jogador
            Vector3 posicaoJogador = jogador.position;

            // Ajusta a posi��o Y da c�mera
            posicaoJogador.y += offsetY;

            // Mant�m a mesma posi��o Z da c�mera
            posicaoJogador.z = transform.position.z;

            // Aplica a interpola��o suave (lerp) para suavizar o movimento da c�mera
            transform.position = Vector3.Lerp(transform.position, posicaoJogador, suavizacao * Time.deltaTime);
        }
    }*/