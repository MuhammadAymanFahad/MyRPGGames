using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float attackRange = 2;
    [SerializeField] private EnemyState enemyState;

    private int facingDirection = 1;
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
        if(Vector2.Distance(transform.position, playerTransform.transform.position) <= attackRange)
        {
            changeState(EnemyState.Attacking);
        }

        else if (playerTransform.position.x > transform.position.x && facingDirection == -1 || playerTransform.position.x < transform.position.x && facingDirection == 1)
        {
            facingDirection *= -1;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        enemyRigidbody.velocity = direction * speed;
    }

    //change back to OnTriggerEnter2D if cannot be fixed
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerTransform == null)
            {
                playerTransform = collision.transform;
            }
            changeState(EnemyState.Chasing);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
}