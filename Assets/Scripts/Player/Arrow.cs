using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody2D arrowRigidBody;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float lifeSpan;
    [SerializeField] private float speed;
    void Start()
    {
        arrowRigidBody.velocity = direction * speed;
        Destroy(this.gameObject, lifeSpan);
    }

    
}
