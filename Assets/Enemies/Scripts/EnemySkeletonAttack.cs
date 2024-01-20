using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeletonAttack : MonoBehaviour
{
    private Animator AnimEnemy;

    public Transform target;
    public float attackRange;
    public float attackCooldown;
    private float timerAttack;
    private float distanceToTarget;

    public GameObject SwordSkeleton;
    private Vector2 initPosAttack;
    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        AnimEnemy = GetComponent<Animator>();
        initPosAttack = SwordSkeleton.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget <= attackRange)
        {
            if (Time.time - timerAttack >= attackCooldown)
            {
                AttackEnemy();
                timerAttack = Time.time;
            }
        }

        FlipHit();
    }

    void FlipHit()
    {
        Vector2 posHit = initPosAttack;

        if (GetComponent<SpriteRenderer>().flipX)
        {
            posHit = new Vector2(-initPosAttack.x, posHit.y);
        }
        else
        {
            posHit = new Vector2(initPosAttack.x, posHit.y);
        }

        SwordSkeleton.transform.localPosition = posHit;
    }

    private void AttackEnemy()
    {
        AnimEnemy.SetTrigger("InAttack");
    }
}
