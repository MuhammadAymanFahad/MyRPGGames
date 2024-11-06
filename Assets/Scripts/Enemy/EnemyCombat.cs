using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private int enemyDamage = 1;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float weaponRange;
    [SerializeField] private LayerMask playerLayer;

    public void enemyAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().changeHealth(-enemyDamage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().changeHealth(-enemyDamage);
        }
    }
}
