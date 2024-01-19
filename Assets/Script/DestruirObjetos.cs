using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestruirObjetos : MonoBehaviour
{
    // Refer�ncias aos objetos que ser�o destru�dos
    public GameObject objeto1;
    public GameObject objeto2;

    // M�todo chamado quando um objeto entra na �rea de trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto que entrou � o jogador (ou tem a tag "Player")
        if (other.CompareTag("Player"))
        {
            // Destroi os objetos referenciados
            Destroy(objeto1);
            Destroy(objeto2);
        }
    }
}


