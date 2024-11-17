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
    public void Knockback(Transform forceTransform, float knockbackForce, float knockbackTime, float stunTime)
    {
        enemyMovement.changeState(EnemyState.Knockedback);
        StartCoroutine(stunTimer(knockbackTime, stunTime));
        Vector2 direction = (transform.position - forceTransform.position).normalized;
        enemyRigidBody.velocity = direction * knockbackForce;
        Debug.Log("Knockback Applied.");
    }

    IEnumerator stunTimer(float knockbackTime, float stunTime) 
    {
        yield return new WaitForSeconds(knockbackTime);
        enemyRigidBody.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.changeState(EnemyState.Idle);
    }
}
