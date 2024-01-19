using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Referência ao transform do objeto de referência
    public Transform objetoReferenciaTransform;

    // Método chamado quando um objeto entra na área de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou é o jogador
        if (other.CompareTag("Player"))
        {
            // Obtém o transform do objeto de referência e atribui ao jogador
            Transform jogadorTransform = other.transform;
            jogadorTransform.position = objetoReferenciaTransform.position;

            // Você pode ajustar conforme necessário, por exemplo, apenas copiando a posição
            // jogadorTransform.position = objetoReferenciaTransform.position;
        }
    }
    
}
