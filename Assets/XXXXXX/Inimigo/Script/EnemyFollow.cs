using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speedMove;                                                         // Velocidade de movimento do Enemy
    public float distanceTarget;                                                    // Dist�ncia m�xima para seguir o Player
    public Transform pointA;                                                        // Ponto A para movimenta��o do Enemy
    public Transform pointB;                                                        // Ponto B para movimenta��o do Enemy
    private Rigidbody2D rb;                                                         // Refer�ncia ao componente Rigidbody2D
    private Vector2 directionTarget;                                                // Dire��o para o pr�ximo destino
    private Animator animEnemy;                                                     // Refer�ncia ao componente Animator do Enemy
    public float destroyHeight = -5f;                                               // Altura para destruir o Enemy
    private bool isDead = false;                                                    // Indica��o se o Enemy est� morto
    private bool canFollowPlayer = false;                                           // Indica��o se o Enemy pode seguir o Player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();                                           // Obter o componente Rigidbody no Enemy
        animEnemy = GetComponent<Animator>();                                       // Obter o componente Animator no Enemy
        SetNewDestination();                                                        // Chamar a fun��o de defini��o de novo destino inicial

        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy != gameObject) // N�o compara com o pr�prio inimigo
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
            return;                                                                 // Se o Enemy estiver morto, interrompe a execu��o do restante do c�digo em Update()
        }

        Vector3 playerTargetPos = new Vector2(GameManager.instance.getPlayer().transform.position.x, transform.position.y);     // Posi��o alvo do Player
        bool playerInsidePoints = IsPlayerInsidePoints(playerTargetPos);            // Verificar se o Player est� entre os pontos A e B


        if (canFollowPlayer && playerInsidePoints)
        {
            directionTarget = (playerTargetPos - transform.position).normalized;    // Define a dire��o para o Player
        }

        FlipSprite();                                                               // Chamar a fun��o de inverter o Sprite do inimigo

        if (canFollowPlayer && Vector2.Distance(transform.position, playerTargetPos) <= distanceTarget)
        {
            directionTarget = Vector2.zero;                                         // Parar o movimento se o jogador estiver dentro da dist�ncia do alvo
            animEnemy.SetBool("IsRunning", false);
        }
        else
        {
            animEnemy.SetBool("IsRunning", true);                                   // Definir o par�metro de anima��o de corrida se o Player estiver fora da dist�ncia do alvo
        }

        CheckForDestroy();                                                          // Chamar a fun��o de verifica��o se o Enemy deve ser destru�do
    }

    public void DeathEnemy()
    {
        isDead = true;                                                              // Define o Enemy como morto
        animEnemy.SetBool("IsRunning", false);                                      // Definir o par�metro de anima��o de corrido como falsa
        rb.velocity = Vector2.zero;                                                 // Zera a velocidade do Rigidbody2D
        canFollowPlayer = false;                                                    // Impede o Enemy de seguir o Player

        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null)
        {
            Physics2D.IgnoreCollision(enemyCollider, GameManager.instance.getPlayer().GetComponent<Collider2D>());      // Ignorar colis�o com o Player
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");                                          // Ignorar colis�o com outros Enemies ap�s a morte
            foreach (GameObject enemy in enemies)
            {
                Collider2D enemyColliderToIgnore = enemy.GetComponent<Collider2D>();                                    // Obt�m o Collider2D do outro Enemy
                if (enemyColliderToIgnore != null && enemyColliderToIgnore != enemyCollider)
                {
                    Physics2D.IgnoreCollision(enemyCollider, enemyColliderToIgnore);                                    // Ignorea a colis�o entre o Enemy atual e outros Enemies
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isDead)
        {
            return;                                                                 // Se o Enemy estiver morto, interrompe a execu��o do restante do c�digo em FixedUpdate()
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

    void FlipSprite()                                                               // Inverter os Sprites do Enemy com base na dire��o
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
            Destroy(gameObject);                                                    // Destr�i o Enemy se estiver abaixo da altura de destrui��o
        }
    }
    bool IsPlayerInsidePoints(Vector3 playerPosition)                               // Verificar se o Player est� entre os pontos A e B
    {
        float minX = Mathf.Min(pointA.position.x, pointB.position.x);
        float maxX = Mathf.Max(pointA.position.x, pointB.position.x);

        return playerPosition.x >= minX && playerPosition.x <= maxX;
    }


    private void OnTriggerEnter2D(Collider2D collision)                             // Manipula a colis�o com triggers (usado para inverter a dire��o quando atinge os pontos A ou B)
    {
        if (collision.CompareTag("pointA") || collision.CompareTag("pointB"))
        {
            directionTarget *= -1;                                                  // Inverter a dire��o ao atingir os pontos A ou B
        }   
        canFollowPlayer = true;                                                     // Permite que o Enemy siga o Player
    }

    private void OnCollisionEnter2D(Collision2D collision)                          // Manipula a colis�o com objetos f�sicos (usado para inverter a dire��o quando colide com os pontos A ou B)
    {
        if (collision.collider.CompareTag("pointA") || collision.collider.CompareTag("pointB"))     
        {
            directionTarget *= -1;                                                  // Inverter a dire��o ao colidir com os pontos A ou B
        }
    }
}
