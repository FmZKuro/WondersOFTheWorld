using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{    
    public Transform objetoReferenciaTransform;                                 // Referência ao transform do objeto de referência
       
    private void OnTriggerEnter2D(Collider2D other)                             // Método chamado quando um objeto entra na área de trigger
    {        
        if (other.CompareTag("Player"))                                         // Verifica se o objeto que entrou é o Player
        {            
            Transform jogadorTransform = other.transform;                       // Obtém o transform do objeto de referência e atribui ao Player
            jogadorTransform.position = objetoReferenciaTransform.position;
        }
    }    
}
