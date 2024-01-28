using UnityEngine;
using UnityEngine.InputSystem;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPosition;                                     // Vari�vel para armazenar a posi��o de respawn do Player
    private Animator AnimPlayer;                                         // Refer�ncia ao componente Animator do Player
    void Start()
    {
        AnimPlayer = GetComponent<Animator>();                           // Obt�m o componente Animator do Player durante o in�cio
    }

    void Update()
    {
        if(GetComponent<Health>().getCurrentHealth() == 0)               // Verifica se a sa�de atual do Player � igual a zero (indicando que o Player est� morto)
        {
            AnimPlayer.SetBool("IsDeath", false);                        // Desativa a anima��o de morte
            transform.position = respawnPosition;                        // Move o Player para a posi��o de respawn
            GetComponent<Health>().setCurrentHealth(5);                  // Define a sa�de do Player de volta a um valor inicial
        }
    }

    void OnTriggerEnter2D(Collider2D other)                              // Chamado quando o Player colide com algum Collider2D
    {       
        if (other.CompareTag("respawplayer"))                            // Verifica se o Player colidiu com um objeto que tem a tag "respawplayer"
        {            
            respawnPosition = other.transform.position;                  // Salva a posi��o do objeto com a tag "respawplayer"                        
            Debug.Log("Posi��o de respawn salva: " + respawnPosition);   // Exemplo de como voc� pode usar a posi��o salva
        }
                
        if (other.CompareTag("death"))                                   // Verifica se o Player colidiu com um objeto que tem a tag "death"
        {
            transform.position = respawnPosition;                        // Define a posi��o do Player para a posi��o salva
        }
    }
}
