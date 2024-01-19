using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public float speedMove;
    public float distanceTarget;
    public Transform pointA;
    public Transform pointB;
    private Rigidbody2D rb;
    private Vector2 directionTarget;
    private Animator animEnemy;
    public float destroyHeight = -5f;
    private bool isDead = false;
    private bool canFollowPlayer = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animEnemy = GetComponent<Animator>();
        SetNewDestination();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        Vector3 playerTargetPos = new Vector2(GameManager.instance.getPlayer().transform.position.x, transform.position.y); 
        bool playerInsidePoints = IsPlayerInsidePoints(playerTargetPos);



        if (canFollowPlayer && playerInsidePoints)
        {
            directionTarget = (playerTargetPos - transform.position).normalized;
        }

        FlipSprite();

        if (canFollowPlayer && Vector2.Distance(transform.position, playerTargetPos) <= distanceTarget)
        {
            directionTarget = Vector2.zero;
            animEnemy.SetBool("IsRunning", false);
        }
        else
        {
            animEnemy.SetBool("IsRunning", true);
        }

        CheckForDestroy();
    }

    public void DeathEnemy()
    {
        isDead = true;
        animEnemy.SetBool("IsRunning", false);
        rb.velocity = Vector2.zero;
        canFollowPlayer = false;

        Collider2D enemyCollider = GetComponent<Collider2D>();
        if (enemyCollider != null)
        {
            Physics2D.IgnoreCollision(enemyCollider, GameManager.instance.getPlayer().GetComponent<Collider2D>());
        }
    }

    void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        rb.velocity = new Vector2(directionTarget.x * speedMove, rb.velocity.y);
    }

    void SetNewDestination()
    {
        if (Random.Range(0, 2) == 0)
        {
            directionTarget = (pointA.position - transform.position).normalized;
        }
        else
        {
            directionTarget = (pointB.position - transform.position).normalized;
        }

        canFollowPlayer = false;
    }

    void FlipSprite()
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
            Destroy(gameObject);
        }
    }
    bool IsPlayerInsidePoints(Vector3 playerPosition)
    {
        float minX = Mathf.Min(pointA.position.x, pointB.position.x);
        float maxX = Mathf.Max(pointA.position.x, pointB.position.x);

        return playerPosition.x >= minX && playerPosition.x <= maxX;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pointA") || collision.CompareTag("pointB"))
        {
            directionTarget *= -1;
        }
        canFollowPlayer = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("pointA") || collision.collider.CompareTag("pointB"))
        {
            directionTarget *= -1;
        }
    }
}