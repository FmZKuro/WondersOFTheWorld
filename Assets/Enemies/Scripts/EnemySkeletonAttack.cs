using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAttack : MonoBehaviour
{
    private Animator AnimEnemy;                                                     // Referência ao componente Animator do Enemy

    public Transform target;                                                        // Transform do Player
    public float attackRange;                                                       // Distância máxima para atacar o Player
    public float attackCooldown;                                                    // Tempo mínimo entre ataques
    private float timerAttack;                                                      // Temporizador para controlar o tempo entre ataques
    private float distanceToTarget;                                                 // Distância atual até o alvo
    public AudioClip attackEnemySound;
    public GameObject SwordSkeleton;                                                // GameObject da espada do Skeleton
    private Vector2 initPosAttack;                                                  // Posição inicial da espada
    public Transform playerTransform;                                               // Transform do Player para ajustar a orientação da caixa de colsião


    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = GetComponent<Animator>();                                       // Obter o componente Animator no Enemy
        initPosAttack = SwordSkeleton.transform.localPosition;                      // Armazena a posição inicial da espada
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);   // Calcula a distância entre o Enemy e o Player

        if (distanceToTarget <= attackRange)                                        // Verifica se o Player está dentro da distância de ataque
        {
            if (Time.time - timerAttack >= attackCooldown)                          // Verificar se o Cooldown entre os ataques foi atingido
            {
                AttackEnemy();                                                      // Chamar a função para atacar
                timerAttack = Time.time;                                            // Reiniciar o temporizador do ataque
            }
        }

        FlipHit();                                                                  // Chamar a função de atualizar a orientação da caixa de colisão do ataque
    }

    void FlipHit()
    {
        Vector2 posHit = initPosAttack;                                             // Inicializa a posição da espada

        if (GetComponent<SpriteRenderer>().flipX)                                   // Verifica se o Enemy está virado para a esquerda e ajusta a posição da espada
        {
            posHit = new Vector2(-initPosAttack.x, posHit.y);
        }
        else                                                                        // Se o Enemy não estiver virado para a esquerda, ajusta a posição da espada normalmente
        {
            posHit = new Vector2(initPosAttack.x, posHit.y);
        }

        SwordSkeleton.transform.localPosition = posHit;                             // Define a posição da espada
    }

    private void AttackEnemy()
    {
        AnimEnemy.SetTrigger("InAttack");                                           // Definir o parâmetro de animação de ataque do Enemy
        SoundEffectControler.instance.playSound(attackEnemySound, 0.5f);
    }
}
