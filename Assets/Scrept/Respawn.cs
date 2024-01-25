using UnityEngine;
using UnityEngine.InputSystem;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPosition;                                       // Vari�vel para armazenar a posi��o de respawn do Player
    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)                                 // Chamado quando o Player colide com algum Collider2D
    {       
        if (other.CompareTag("respawplayer"))                               // Verifica se o Player colidiu com um objeto que tem a tag "respawplayer"
        {            
            respawnPosition = other.transform.position;                     // Salva a posi��o do objeto com a tag "respawplayer"                        
            Debug.Log("Posi��o de respawn salva: " + respawnPosition);      // Exemplo de como voc� pode usar a posi��o salva
        }
                
        if (other.CompareTag("death"))                                      // Verifica se o Player colidiu com um objeto que tem a tag "death"
        {
            GetComponent<Health>().takeDamage();                            // Player sofre dano ap�s colidir com um objeto que tem a tag "death"
            transform.position = respawnPosition;                           // Define a posi��o do Player para a posi��o salva
        }
    }
}