using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private int enemyDamage = 1;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float weaponRange;
    [SerializeField] private float knockBackForce;
    [SerializeField] private float stunTime;
    [SerializeField] private LayerMask playerLayer;

    public void enemyAttack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().changeHealth(-enemyDamage);
            hits[0].GetComponent<PlayerMovement>().knockBack(transform, knockBackForce, stunTime);
        }
    }
}
