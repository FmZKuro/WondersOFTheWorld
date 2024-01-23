using UnityEngine;
using UnityEngine.InputSystem;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPosition;
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o jogador colidiu com um objeto que tem a tag "respawplayer"
        if (other.CompareTag("respawplayer"))
        {
            // Salva a posição do objeto com a tag "respawplayer"
            respawnPosition = other.transform.position;

            // Exemplo de como você pode usar a posição salva
            Debug.Log("Posição de respawn salva: " + respawnPosition);

            // Aqui, você pode chamar uma função ou fazer qualquer outra coisa com a posição salva
        }

        // Verifica se o jogador colidiu com um objeto que tem a tag "death"
        if (other.CompareTag("death"))
        {
            // Define a posição do jogador para a posição salva
            transform.position = respawnPosition;

            // Aqui, você pode chamar uma função ou fazer qualquer outra coisa após o respawn
        }
    }

}