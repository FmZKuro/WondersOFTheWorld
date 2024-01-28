using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator AnimEnemy;                                                     // Referência ao componente Animator do Enemy

    public Transform target;                                                        // Transform do Player
    public float attackRange;                                                       // Distância máxima para atacar o Player
    public float attackCooldown;                                                    // Tempo mínimo entre ataques
    private float timerAttack;                                                      // Temporizador para controlar o tempo entre ataques
    private float distanceToTarget;                                                 // Distância atual até o alvo
    public AudioClip attackEnemySound;
    public Collider2D attackHitBox;                                                 // Caixa de colisão para detectar o alcance do ataque
    public Transform playerTransform;                                               // Transform do Player para ajustar a orientação da caixa de colsião

    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = GetComponent<Animator>();                                       // Obter o componente Animator no Enemy
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);   // Calcular a distância entre o Enemy e o Player

        if (distanceToTarget <= attackRange)                                        // Verificar se o Player está dentro da distância de ataque
        {
            if (Time.time - timerAttack >= attackCooldown && GetComponent<Health>().currentHealth > 0) // Verificar se o Cooldown entre os ataques foi atingido
            {
                AttackEnemy();                                                      // Chamar a função para atacar
                timerAttack = Time.time;                                            // Reiniciar o temporizador do ataque
            }
        }









            UpdateAttackHitBoxDirection();                                              // Chamar a função de atualizar a orientação da caixa de colisão do ataque
    }

    private void UpdateAttackHitBoxDirection()
    {
        if (playerTransform.position.x < transform.position.x)
        {
            attackHitBox.offset = new Vector2(-attackHitBox.offset.x, attackHitBox.offset.y);   // Ajusta a posição da caixa de colisão se o Player estiver à esquerda
        }
        else
        {
            attackHitBox.offset = new Vector2(Mathf.Abs(attackHitBox.offset.x), attackHitBox.offset.y);     // Ajusta a posição da caixa de colisão se o jogador estiver à direita
        }
    }

    private void AttackEnemy()
    {
        AnimEnemy.SetTrigger("InAttack");                                           // Definir o parâmetro de animação de ataque do Enemy        
        SoundEffectControler.instance.playSound(attackEnemySound, 0.5f);
    }
}
