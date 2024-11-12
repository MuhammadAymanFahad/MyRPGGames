using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float attackRange = 2;
    [SerializeField] private float attackCooldown = 2;
    [SerializeField] private float playerDetectRange = 6;
    [SerializeField] private Transform detectionPoint;
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private LayerMask playerLayer;

    private int facingDirection = 1;
    private float attackCooldownTimer;
    private Rigidbody2D enemyRigidbody;
    private Transform playerTransform;
    private Animator enemyAnim;

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponent<Animator>();
        changeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState != EnemyState.Knockedback)
        {
            checkForPlayer();
            if (attackCooldownTimer > 0)
            {
                attackCooldownTimer -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                enemyChase();
            }
            else if (enemyState == EnemyState.Attacking)
            {
                enemyRigidbody.velocity = Vector2.zero;
            }
        }

    }

    void enemyChase()
    {
        if (playerTransform.position.x > transform.position.x && facingDirection == -1 || playerTransform.position.x < transform.position.x && facingDirection == 1)
        {
            facingDirection *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        enemyRigidbody.velocity = direction * speed;
    }

    private void checkForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);

        if (hits.Length > 0)
        {
            playerTransform = hits[0].transform;

            //if player in attack range AND cooldown is ready
            if (Vector2.Distance(transform.position, playerTransform.position) <= attackRange && attackCooldownTimer <= 0)
            {
                attackCooldownTimer = attackCooldown;
                changeState(EnemyState.Attacking);
            }

            else if (Vector2.Distance(transform.position, playerTransform.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                changeState(EnemyState.Chasing);
            }
        }

        else
        {
            enemyRigidbody.velocity = Vector2.zero;
            changeState(EnemyState.Idle);
        }
    }

    public void changeState(EnemyState newState)
    {
        //exit the current animation
        if (enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            enemyAnim.SetBool("isAttacking", false);
        //else if (enemyState == EnemyState.Knockedback)
            //enemyAnim.SetBool("isKnockedback", false);
        //update the current animation
        enemyState = newState;
        //update the new animation
        if (enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", true);
        else if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", true);
        else if (enemyState == EnemyState.Attacking)
            enemyAnim.SetBool("isAttacking", true);
        //else if (enemyState == EnemyState.Knockedback)
            //enemyAnim.SetBool("isKnockedback", true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockedback,
}