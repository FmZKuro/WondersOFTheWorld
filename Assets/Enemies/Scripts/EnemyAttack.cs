using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator AnimEnemy;                                                     // Refer�ncia ao componente Animator do Enemy

    public Transform target;                                                        // Transform do Player
    public float attackRange;                                                       // Dist�ncia m�xima para atacar o Player
    public float attackCooldown;                                                    // Tempo m�nimo entre ataques
    private float timerAttack;                                                      // Temporizador para controlar o tempo entre ataques
    private float distanceToTarget;                                                 // Dist�ncia atual at� o alvo
    public AudioClip attackEnemySound;
    public Collider2D attackHitBox;                                                 // Caixa de colis�o para detectar o alcance do ataque
    public Transform playerTransform;                                               // Transform do Player para ajustar a orienta��o da caixa de colsi�o

    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = GetComponent<Animator>();                                       // Obter o componente Animator no Enemy
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);   // Calcular a dist�ncia entre o Enemy e o Player

        if (distanceToTarget <= attackRange)                                        // Verificar se o Player est� dentro da dist�ncia de ataque
        {
            if (Time.time - timerAttack >= attackCooldown && GetComponent<Health>().currentHealth > 0) // Verificar se o Cooldown entre os ataques foi atingido
            {
                AttackEnemy();                                                      // Chamar a fun��o para atacar
                timerAttack = Time.time;                                            // Reiniciar o temporizador do ataque
            }
        }









            UpdateAttackHitBoxDirection();                                              // Chamar a fun��o de atualizar a orienta��o da caixa de colis�o do ataque
    }

    private void UpdateAttackHitBoxDirection()
    {
        if (playerTransform.position.x < transform.position.x)
        {
            attackHitBox.offset = new Vector2(-attackHitBox.offset.x, attackHitBox.offset.y);   // Ajusta a posi��o da caixa de colis�o se o Player estiver � esquerda
        }
        else
        {
            attackHitBox.offset = new Vector2(Mathf.Abs(attackHitBox.offset.x), attackHitBox.offset.y);     // Ajusta a posi��o da caixa de colis�o se o jogador estiver � direita
        }
    }

    private void AttackEnemy()
    {
        AnimEnemy.SetTrigger("InAttack");                                           // Definir o par�metro de anima��o de ataque do Enemy        
        SoundEffectControler.instance.playSound(attackEnemySound, 0.5f);
    }
}
