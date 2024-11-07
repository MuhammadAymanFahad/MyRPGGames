using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float weaponRange;
    [SerializeField] private float knockbackForce;
    private float timer;
    public int damage;

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void attack()
    {
        if(timer <= 0)
        {
            playerAnim.SetBool("isAttacking", true);



            timer = attackCooldown;
        }
    }

    public void dealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().changeHealth(-damage);
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce);
        }
    }

    public void finishAttacking()
    {
        playerAnim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}
