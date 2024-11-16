using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D arrowRigidBody;
    [SerializeField] private float lifeSpan;
    [SerializeField] private float speed;
    public Vector2 direction;
    void Start()
    {
        arrowRigidBody.velocity = direction * speed;
        Destroy(gameObject, lifeSpan);
    }

    
}
