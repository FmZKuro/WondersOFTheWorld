using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{    
    public Transform objetoReferenciaTransform;                                 // Refer�ncia ao transform do objeto de refer�ncia
       
    private void OnTriggerEnter2D(Collider2D other)                             // M�todo chamado quando um objeto entra na �rea de trigger
    {        
        if (other.CompareTag("Player"))                                         // Verifica se o objeto que entrou � o Player
        {            
            Transform jogadorTransform = other.transform;                       // Obt�m o transform do objeto de refer�ncia e atribui ao Player
            jogadorTransform.position = objetoReferenciaTransform.position;
        }
    }    
}
