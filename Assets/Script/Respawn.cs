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
            // Salva a posi��o do objeto com a tag "respawplayer"
            respawnPosition = other.transform.position;

            // Exemplo de como voc� pode usar a posi��o salva
            Debug.Log("Posi��o de respawn salva: " + respawnPosition);

            // Aqui, voc� pode chamar uma fun��o ou fazer qualquer outra coisa com a posi��o salva
        }

        // Verifica se o jogador colidiu com um objeto que tem a tag "death"
        if (other.CompareTag("death"))
        {
            // Define a posi��o do jogador para a posi��o salva
            transform.position = respawnPosition;

            // Aqui, voc� pode chamar uma fun��o ou fazer qualquer outra coisa ap�s o respawn
        }
    }

}