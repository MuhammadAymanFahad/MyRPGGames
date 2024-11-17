using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D arrowRigidBody;
    [SerializeField] private float lifeSpan;
    [SerializeField] private float speed;
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
}
