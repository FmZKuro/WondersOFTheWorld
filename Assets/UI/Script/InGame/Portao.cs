using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portao : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player"; // Tag do jogador
    [SerializeField] private GameObject uiImage;         // Imagem de UI a ser ativada

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o objeto colidido tem a tag do jogador
        if (other.CompareTag(playerTag))
        {
            // Ativa a imagem de UI
            uiImage.SetActive(true);
        }
    }
}
