using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    [SerializeField] private Rigidbody2D enemyRigidBody;

    private void Start()
    {
        enemyRigidBody = GetComponent<Rigidbody2D>();
    }
    public void Knockback(Transform playerTransform, float knockbackForce)
    {
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        enemyRigidBody.velocity = direction * knockbackForce;
        Debug.Log("Knockback Applied.");
    }
}
