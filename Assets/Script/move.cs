using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    Rigidbody2D rb;
    Animator playerAnim;
    public float moveSpeed = 8f; // Velocidade de movimento do personagem
    float jumpForce = 10f; // Força do pulo do personagem
    bool isGrounded = true; // Verifica se o personagem está no chão
    private Vector3 respawnPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void Update()
    {
        tesc(); // Chama a função para verificar as teclas pressionadas
        AtualizarAnimacao();

    }

    // ... (seu código anterior)

    void tesc()
    {
        Vector2 movement = Vector2.zero;

        if (Keyboard.current.leftArrowKey.isPressed)
        {
            movement.x = -1; // Movimento para a esquerda
        }
        else if (Keyboard.current.rightArrowKey.isPressed)
        {
            movement.x = 1; // Movimento para a direita
        }

        // Verifica se está no chão e permite o pulo
        if (Keyboard.current.upArrowKey.wasPressedThisFrame && isGrounded)
        {
            Pular();
        }

        // Aplica o movimento horizontal ao Rigidbody
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);
    }

    void Pular()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false; // Indica que o personagem está no ar
    }

    void AtualizarAnimacao()
    {
        float move = rb.velocity.x;

        if (isGrounded)
        {
            if (move != 0) // Se estiver se movendo
            {
                if (move > 0) // Se estiver se movendo para a direita
                {
                    playerAnim.SetBool("isRunRight", true); // Ativar a animação de corrida para direita
                    playerAnim.SetBool("isRunLeft", false); // Desativar a animação de corrida para esquerda
                }
                else if (move < 0) // Se estiver se movendo para a esquerda
                {
                    playerAnim.SetBool("isRunLeft", true); // Ativar a animação de corrida para esquerda
                    playerAnim.SetBool("isRunRight", false); // Desativar a animação de corrida para direita
                }
            }
            else // Se não estiver se movendo
            {
                playerAnim.SetBool("isRunRight", false); // Desativar a animação de corrida para direita
                playerAnim.SetBool("isRunLeft", false); // Desativar a animação de corrida para esquerda
            }

            playerAnim.SetBool("isJump", false); // Desativar a animação de pulo se estiver no chão
        }
        else // Se estiver no ar
        {
            playerAnim.SetBool("isJump", true); // Ativar a animação de pulo enquanto estiver no ar
            playerAnim.SetBool("isRunRight", false); // Desativar a animação de corrida para direita no ar
            playerAnim.SetBool("isRunLeft", false); // Desativar a animação de corrida para esquerda no ar
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // O personagem está no chão
        }


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