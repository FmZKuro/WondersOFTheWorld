using UnityEngine;
using UnityEngine.InputSystem;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPosition;                                     // Variável para armazenar a posição de respawn do Player
    private Animator AnimPlayer;                                         // Referência ao componente Animator do Player
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();                           // Obtém o componente Animator do Player durante o início
    }

    void Update()
    {
        if(GetComponent<Health>().getCurrentHealth() == 0)               // Verifica se a saúde atual do Player é igual a zero (indicando que o Player está morto)
        {
            AnimPlayer.SetBool("IsDeath", false);                        // Desativa a animação de morte
            transform.position = respawnPosition;                        // Move o Player para a posição de respawn
            GetComponent<Health>().setCurrentHealth(5);                  // Define a saúde do Player de volta a um valor inicial
        }
    }

    void OnTriggerEnter2D(Collider2D other)                              // Chamado quando o Player colide com algum Collider2D
    {       
        if (other.CompareTag("respawplayer"))                            // Verifica se o Player colidiu com um objeto que tem a tag "respawplayer"
        {            
            respawnPosition = other.transform.position;                  // Salva a posição do objeto com a tag "respawplayer"                        
            Debug.Log("Posição de respawn salva: " + respawnPosition);   // Exemplo de como você pode usar a posição salva
        }
                
        if (other.CompareTag("death"))                                   // Verifica se o Player colidiu com um objeto que tem a tag "death"
        {
            transform.position = respawnPosition;                        // Define a posição do Player para a posição salva
        }
    }
}
