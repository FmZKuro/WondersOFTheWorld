using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAttack : MonoBehaviour
{
    private Animator AnimEnemy;                                                     // Refer�ncia ao componente Animator do Enemy

    public Transform target;                                                        // Transform do Player
    public float attackRange;                                                       // Dist�ncia m�xima para atacar o Player
    public float attackCooldown;                                                    // Tempo m�nimo entre ataques
    private float timerAttack;                                                      // Temporizador para controlar o tempo entre ataques
    private float distanceToTarget;                                                 // Dist�ncia atual at� o alvo
    public AudioClip attackEnemySound;
    public GameObject SwordSkeleton;                                                // GameObject da espada do Skeleton
    private Vector2 initPosAttack;                                                  // Posi��o inicial da espada
    public Transform playerTransform;                                               // Transform do Player para ajustar a orienta��o da caixa de colsi�o


    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = GetComponent<Animator>();                                       // Obter o componente Animator no Enemy
        initPosAttack = SwordSkeleton.transform.localPosition;                      // Armazena a posi��o inicial da espada
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);   // Calcula a dist�ncia entre o Enemy e o Player

        if (distanceToTarget <= attackRange)                                        // Verifica se o Player est� dentro da dist�ncia de ataque
        {
            if (Time.time - timerAttack >= attackCooldown)                          // Verificar se o Cooldown entre os ataques foi atingido
            {
                AttackEnemy();                                                      // Chamar a fun��o para atacar
                timerAttack = Time.time;                                            // Reiniciar o temporizador do ataque
            }
        }

        FlipHit();                                                                  // Chamar a fun��o de atualizar a orienta��o da caixa de colis�o do ataque
    }

    void FlipHit()
    {
        Vector2 posHit = initPosAttack;                                             // Inicializa a posi��o da espada

        if (GetComponent<SpriteRenderer>().flipX)                                   // Verifica se o Enemy est� virado para a esquerda e ajusta a posi��o da espada
        {
            posHit = new Vector2(-initPosAttack.x, posHit.y);
        }
        else                                                                        // Se o Enemy n�o estiver virado para a esquerda, ajusta a posi��o da espada normalmente
        {
            posHit = new Vector2(initPosAttack.x, posHit.y);
        }

        SwordSkeleton.transform.localPosition = posHit;                             // Define a posi��o da espada
    }

    private void AttackEnemy()
    {
        AnimEnemy.SetTrigger("InAttack");                                           // Definir o par�metro de anima��o de ataque do Enemy
        SoundEffectControler.instance.playSound(attackEnemySound, 0.5f);
    }
}
