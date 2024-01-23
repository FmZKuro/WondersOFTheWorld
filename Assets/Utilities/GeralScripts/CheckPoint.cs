using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform player;                            // Referência para o Transform do Player
    private Vector3 respawnPoint;                       // Ponto de respawn inicial do Player

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = player.position;                 // Define o ponto de respawn inicial como a posição atual do Player
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)             // Chamado quando um objeto entra no trigger associado a este Collider2D
    {
        if (other.CompareTag("Player"))
        {
            respawnPoint = transform.position;          // Atualiza o ponto de respawn quando o Player entra no trigger
        }
    }

    public void ResPlayer()                             // Função para ressuscitar o Player no ponto de respawn
    {
        player.position = respawnPoint;                 // Reposiciona o Player no último ponto de respawn registrado
    }
}
