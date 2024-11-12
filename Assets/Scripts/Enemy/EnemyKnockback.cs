using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidBody;
    [SerializeField] private EnemyMovement enemyMovement;

    private void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    public void Knockback(Transform playerTransform, float knockbackForce, float stunTime)
    {
        enemyMovement.changeState(EnemyState.Knockedback);
        StartCoroutine(stunTimer(stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        enemyRigidBody.velocity = direction * knockbackForce;
        Debug.Log("Knockback Applied.");
    }

    IEnumerator stunTimer(float stunTime) 
    {
        yield return new WaitForSeconds(stunTime);
        enemyRigidBody.velocity = Vector2.zero;
        enemyMovement.changeState(EnemyState.Idle);
    }
}
