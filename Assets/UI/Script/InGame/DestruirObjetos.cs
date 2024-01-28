using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestruirObjetos : MonoBehaviour
{    

    public GameObject objeto1;
    public GameObject objeto2;
        
    private void OnTriggerEnter2D(Collider2D other)         // Método chamado quando um objeto entra na área de trigger
    {        
        if (other.CompareTag("Player"))                     // Verifica se o objeto que entrou é o Player (ou tem a tag "Player")
        {            
            Destroy(objeto1);                               // Destroi os objetos referenciados
            Destroy(objeto2);
        }
    }
}


