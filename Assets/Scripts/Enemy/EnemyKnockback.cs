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
    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        enemyMovement.changeState(EnemyState.Knockedback);
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        enemyRigidBody.velocity = direction * knockbackForce;
        Debug.Log("Knockback Applied.");
    }
}
