using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadQuef : MonoBehaviour
{
    public string cenaDestino = "quefren"; // Nome da cena para a qual transportar o jogador

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entrou na zona de transporte!");

            // Certifique-se de que a cena está no Build Settings
            if (SceneManager.GetSceneByName(cenaDestino) != null)
            {
                // Transportar para a cena desejada
                SceneManager.LoadScene(cenaDestino);
            }
            else
            {
                Debug.LogError($"A cena {cenaDestino} não está no Build Settings.");
            }
        }
    }
}
