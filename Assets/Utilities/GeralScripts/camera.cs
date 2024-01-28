using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class camera : MonoBehaviour
{
    public Transform jogador;                                                   // Refer�ncia ao objeto do Player
    public float offsetY = 1.3f;                                                // Offset na posi��o Y da c�mera
    public float followSpeed = 2.0f;                                            // Velocidade da camera


    void Update()
    {                                                                           // Calcula a nova posi��o da c�mera com base na posi��o do Player e no offset em Y
        Vector3 newPosition = new Vector3(jogador.position.x, jogador.position.y + offsetY, -10f);

        Vector3 velocity = Vector3.zero;                                        // Inicializa a velocidade como zero
                                                                                // A velocidade � controlada pela vari�vel followSpeed multiplicada pelo tempo desde o �ltimo frame
        transform.position = Vector3.Slerp(transform.position, newPosition, followSpeed * Time.deltaTime);
    }
}
