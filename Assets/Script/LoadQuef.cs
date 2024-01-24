using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadQuef : MonoBehaviour
{
    public string cenaDestino = "quefren";                          // Nome da cena para a qual transportar o jogador

    void OnTriggerEnter2D(Collider2D other)                         // Chamado quando um objeto entra no trigger associado a este Collider2D
    {
        if (other.CompareTag("Player"))                             // Verifica se o objeto que entrou � o Player
        {
            Debug.Log("Player entrou na zona de transporte!");      // Exibe uma mensagem de log
                        
            if (SceneManager.GetSceneByName(cenaDestino) != null)   // Certifique-se de que a cena est� no Build Settings
            {                
                SceneManager.LoadScene(cenaDestino);                // Transportar para a cena desejada
            }
            else
            {                                                       // Exibe uma mensagem de erro se a cena n�o estiver no Build Settings
                Debug.LogError($"A cena {cenaDestino} n�o est� no Build Settings.");
            }
        }
    }
}
