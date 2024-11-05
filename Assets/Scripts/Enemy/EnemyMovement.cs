using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float speed;
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            enemyRigidbody.velocity = direction * speed;
        }
    }
}
