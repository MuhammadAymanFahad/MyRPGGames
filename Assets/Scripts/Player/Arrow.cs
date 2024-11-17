using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D arrowRigidBody;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackTime;
    [SerializeField] private float stunTime;
    [SerializeField] private float lifeSpan;
    [SerializeField] private float speed;

    [SerializeField] private int damage;
    public Vector2 direction = Vector2.right;

    void Start()
    {
        arrowRigidBody.velocity = direction * speed;
        rotateArrow();
        Destroy(gameObject, lifeSpan);
    }

    void rotateArrow()
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if((enemyLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.GetComponent<EnemyHealth>().changeHealth(-damage);
            collision.gameObject.GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce, knockbackTime, stunTime);
        }
    }
}
