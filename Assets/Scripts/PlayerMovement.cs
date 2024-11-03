using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D playerRigidBody;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        playerMove();
    }

    void playerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        playerRigidBody.velocity = new Vector2(horizontal, vertical) * speed; 
    }
}
