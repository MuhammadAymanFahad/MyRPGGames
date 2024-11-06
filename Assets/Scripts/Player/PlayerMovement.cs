using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Animator playerAnim;
    

    private bool isKnockedBack;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isKnockedBack)
        {
            playerMove();
        }
    }

    void playerMove()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        manageDirection(horizontal, vertical);
        playerAnim.SetFloat("horizontal", Mathf.Abs(horizontal));
        playerAnim.SetFloat("vertical", Mathf.Abs(vertical));

        playerRigidBody.velocity = new Vector2(horizontal, vertical) * speed; 
    }

    void manageDirection(float horizontal, float vertical)
    {
        if((horizontal > 0 && transform.localScale.x < 0) || (horizontal < 0 && transform.localScale.x > 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    public void knockBack(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        playerRigidBody.velocity = direction * force;
        StartCoroutine(knockBackCounter(stunTime));
    }

    IEnumerator knockBackCounter(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        playerRigidBody.velocity = Vector2.zero;
        isKnockedBack = false;
    }
}
