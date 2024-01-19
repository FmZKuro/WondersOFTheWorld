using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    public Transform cameraTransform;
    public float detectionRadius = 5f;
    public LayerMask enemyLayer;
    public float speed = 3f;
    private float distanceToEnemy;
    private float closestDistance;

    private Transform playerTransform;
    private bool isEnemyFollowing = false;
    private Transform targetEnemy;

    void Start()
    {        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {        
        // Mova o detector de inimigos junto com a c�mera
        transform.position = cameraTransform.position;

        // Verifique se h� inimigos dentro do raio de detec��o
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, detectionRadius, enemyLayer);

        // Se houver inimigos, comece a seguir o jogador
        if (hitEnemies.Length > 0)
        {
            isEnemyFollowing = true;

            // Escolha o inimigo mais pr�ximo como alvo
            closestDistance = Mathf.Infinity;
            foreach (Collider2D enemyCollider in hitEnemies)
            {
                distanceToEnemy = Vector2.Distance(transform.position, enemyCollider.transform.position);
                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    targetEnemy = enemyCollider.transform;
                }
            }
        }
        else
        {
            isEnemyFollowing = false;
        }

        // Se estiver seguindo o jogador, mova-se em dire��o a ele
        if (isEnemyFollowing && targetEnemy != null)
        {           
            Vector2 direction = (playerTransform.position - targetEnemy.position).normalized;
            targetEnemy.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            // Se n�o estiver seguindo o jogador, pare de se mover
            isEnemyFollowing = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Desenha um gizmo para visualizar o raio de detec��o na cena
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}

