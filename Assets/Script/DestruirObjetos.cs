using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestruirObjetos : MonoBehaviour
{
    // Referências aos objetos que serão destruídos
    public GameObject objeto1;
    public GameObject objeto2;

    // Método chamado quando um objeto entra na área de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou é o jogador (ou tem a tag "Player")
        if (other.CompareTag("Player"))
        {
            // Destroi os objetos referenciados
            Destroy(objeto1);
            Destroy(objeto2);
        }
    }
}


