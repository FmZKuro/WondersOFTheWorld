using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";   // Tag do Player
    [SerializeField] private GameObject uiImage;            // Imagem de UI a ser ativada

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.CompareTag(playerTag))                    // Verifica se o objeto colidido tem a tag do Player
        {            
            uiImage.SetActive(true);                        // Ativa a imagem de UI
        }
    }
}
