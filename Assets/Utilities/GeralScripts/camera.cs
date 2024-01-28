using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour
{
    public Transform jogador;                                                   // Referência ao objeto do Player
    public float offsetY = 1.3f;                                                // Offset na posição Y da câmera
    public float followSpeed = 2.0f;                                            // Velocidade da camera


    void Update()
    {                                                                           // Calcula a nova posição da câmera com base na posição do Player e no offset em Y
        Vector3 newPosition = new Vector3(jogador.position.x, jogador.position.y + offsetY, -10f);

        Vector3 velocity = Vector3.zero;                                        // Inicializa a velocidade como zero
                                                                                // A velocidade é controlada pela variável followSpeed multiplicada pelo tempo desde o último frame
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
