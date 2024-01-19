using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator AnimEnemy;

    public Transform target;
    public float attackRange;
    public float attackCooldown;
    private float timerAttack;
    private float distanceToTarget;

    public Collider2D attackHitBox;
    public Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange)
        {
            if (Time.time - timerAttack >= attackCooldown)
            {
                AttackEnemy();
                timerAttack = Time.time;
            }
        }

        UpdateAttackHitBoxDirection();
    }

    private void UpdateAttackHitBoxDirection()
    {
        if (playerTransform.position.x < transform.position.x)
        {
            attackHitBox.offset = new Vector2(-attackHitBox.offset.x, attackHitBox.offset.y);
        }
        else
        {
            attackHitBox.offset = new Vector2(Mathf.Abs(attackHitBox.offset.x), attackHitBox.offset.y);
        }
    }

    private void AttackEnemy()
    {
        AnimEnemy.SetTrigger("InAttack");
    }

}
