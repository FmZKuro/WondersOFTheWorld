using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Refer�ncia ao transform do objeto de refer�ncia
    public Transform objetoReferenciaTransform;

    // M�todo chamado quando um objeto entra na �rea de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou � o jogador
        if (other.CompareTag("Player"))
        {
            // Obt�m o transform do objeto de refer�ncia e atribui ao jogador
            Transform jogadorTransform = other.transform;
            jogadorTransform.position = objetoReferenciaTransform.position;

            // Voc� pode ajustar conforme necess�rio, por exemplo, apenas copiando a posi��o
            // jogadorTransform.position = objetoReferenciaTransform.position;
        }
    }
    
}
