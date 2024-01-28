using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speedMove;                                                         // Velocidade de movimento do Enemy
    public float distanceTarget;                                                    // Distância máxima para seguir o Player
    public Transform pointA;                                                        // Ponto A para movimentação do Enemy
    public Transform pointB;                                                        // Ponto B para movimentação do Enemy
    private Rigidbody2D rb;                                                         // Referência ao componente Rigidbody2D
    private Vector2 directionTarget;                                                // Direção para o próximo destino
    private Animator animEnemy;                                                     // Referência ao componente Animator do Enemy
    public float destroyHeight = -5f;                                               // Altura para destruir o Enemy
    private bool isDead = false;                                                    // Indicação se o Enemy está morto
    private bool canFollowPlayer = false;                                           // Indicação se o Enemy pode seguir o Player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                           // Obter o componente Rigidbody no Enemy
        animEnemy = GetComponent<Animator>();                                       // Obter o componente Animator no Enemy
        SetNewDestination();                                                        // Chamar a função de definição de novo destino inicial

        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy != gameObject) // Não compara com o próprio inimigo
                {
                    Collider2D otherEnemyCollider = enemy.GetComponent<Collider2D>();
                    if (otherEnemyCollider != null)
                    {
                        Physics2D.IgnoreCollision(enemyCollider, otherEnemyCollider);
                    }
                }
            }
        }

    }

    void Update()
    {
        if (isDead)
        {
            return;                                                                 // Se o Enemy estiver morto, interrompe a execução do restante do código em Update()
        }

        Vector3 playerTargetPos = new Vector2(GameManager.instance.getPlayer().transform.position.x, transform.position.y);     // Posição alvo do Player
        bool playerInsidePoints = IsPlayerInsidePoints(playerTargetPos);            // Verificar se o Player está entre os pontos A e B


        if (canFollowPlayer && playerInsidePoints)
        {
            directionTarget = (playerTargetPos - transform.position).normalized;    // Define a direção para o Player
        }

        FlipSprite();                                                               // Chamar a função de inverter o Sprite do inimigo

        if (canFollowPlayer && Vector2.Distance(transform.position, playerTargetPos) <= distanceTarget)
        {
            directionTarget = Vector2.zero;                                         // Parar o movimento se o jogador estiver dentro da distância do alvo
            animEnemy.SetBool("IsRunning", false);
        }
        else
        {
            animEnemy.SetBool("IsRunning", true);                                   // Definir o parâmetro de animação de corrida se o Player estiver fora da distância do alvo
        }

        CheckForDestroy();                                                          // Chamar a função de verificação se o Enemy deve ser destruído
    }

    public void DeathEnemy()
    {
        isDead = true;                                                              // Define o Enemy como morto
        animEnemy.SetBool("IsRunning", false);                                      // Definir o parâmetro de animação de corrido como falsa
        rb.velocity = Vector2.zero;                                                 // Zera a velocidade do Rigidbody2D
        canFollowPlayer = false;                                                    // Impede o Enemy de seguir o Player

        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null)
        {
            Physics2D.IgnoreCollision(enemyCollider, GameManager.instance.getPlayer().GetComponent<Collider2D>());      // Ignorar colisão com o Player
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");                                          // Ignorar colisão com outros Enemies após a morte
            foreach (GameObject enemy in enemies)
            {
                Collider2D enemyColliderToIgnore = enemy.GetComponent<Collider2D>();                                    // Obtém o Collider2D do outro Enemy
                if (enemyColliderToIgnore != null && enemyColliderToIgnore != enemyCollider)
                {
                    Physics2D.IgnoreCollision(enemyCollider, enemyColliderToIgnore);                                    // Ignorea a colisão entre o Enemy atual e outros Enemies
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isDead)
        {
            return;                                                                 // Se o Enemy estiver morto, interrompe a execução do restante do código em FixedUpdate()
        }

        rb.velocity = new Vector2(directionTarget.x * speedMove, rb.velocity.y);    // Aplica a velocidade ao RigidBody2D
    }

    void SetNewDestination()
    {
        if (Random.Range(0, 2) == 0)                                                // Escolha um novo destino entre os pontos A e B
        {
            directionTarget = (pointA.position - transform.position).normalized;
        }
        else
        {
            directionTarget = (pointB.position - transform.position).normalized;
        }

        canFollowPlayer = false;                                                    // Impede o Enemy de seguir o Player
    }

    void FlipSprite()                                                               // Inverter os Sprites do Enemy com base na direção
    {
        if (directionTarget.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void CheckForDestroy()
    {
        if (transform.position.y < destroyHeight)
        {
            Destroy(gameObject);                                                    // Destrói o Enemy se estiver abaixo da altura de destruição
        }
    }
    bool IsPlayerInsidePoints(Vector3 playerPosition)                               // Verificar se o Player está entre os pontos A e B
    {
        float minX = Mathf.Min(pointA.position.x, pointB.position.x);
        float maxX = Mathf.Max(pointA.position.x, pointB.position.x);

        return playerPosition.x >= minX && playerPosition.x <= maxX;
    }


    private void OnTriggerEnter2D(Collider2D collision)                             // Manipula a colisão com triggers (usado para inverter a direção quando atinge os pontos A ou B)
    {
        if (collision.CompareTag("pointA") || collision.CompareTag("pointB"))
        {
            directionTarget *= -1;                                                  // Inverter a direção ao atingir os pontos A ou B
        }   
        canFollowPlayer = true;                                                     // Permite que o Enemy siga o Player
    }

    private void OnCollisionEnter2D(Collision2D collision)                          // Manipula a colisão com objetos físicos (usado para inverter a direção quando colide com os pontos A ou B)
    {
        if (collision.collider.CompareTag("pointA") || collision.collider.CompareTag("pointB"))     
        {
            directionTarget *= -1;                                                  // Inverter a direção ao colidir com os pontos A ou B
        }
    }
}
