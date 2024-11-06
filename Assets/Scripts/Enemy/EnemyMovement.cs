using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float attackRange = 2;
    [SerializeField] private float attackCooldown = 2;
    [SerializeField] private float playerDetectRange = 5;
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
        /*
        if (playerTransform != null)
        {
            if(enemyState == EnemyState.Chasing)
            {
                enemyChase();
            }
            else if(enemyState == EnemyState.Attacking)
            {
                enemyRigidbody.velocity = Vector2.zero;
            }
        }
        */
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

    //change back to OnTriggerEnter2D if cannot be fixed, early tutorial suggest to use OnTriggerStay2D
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

            else if (Vector2.Distance(transform.position, playerTransform.position) > attackRange)
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

    void changeState(EnemyState newState)
    {
        //exit the current animation
        if (enemyState == EnemyState.Idle)
            enemyAnim.SetBool("isIdle", false);
        else if (enemyState == EnemyState.Chasing)
            enemyAnim.SetBool("isChasing", false);
        else if (enemyState == EnemyState.Attacking)
            enemyAnim.SetBool("isAttacking", false);
        //update the current animation
        enemyState = newState;
        //update the new animation
        if (enemyState == EnemyState.Idle)
        {
            enemyAnim.SetBool("isIdle", true);
            Debug.Log("Become idle");
        } 
        else if (enemyState == EnemyState.Chasing)
        {
            enemyAnim.SetBool("isChasing", true);
            Debug.Log("Start Following the player");
        } 
        else if (enemyState == EnemyState.Attacking)
        {
            enemyAnim.SetBool("isAttacking", true);
            Debug.Log("Start Attacking state");
        }  
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
}