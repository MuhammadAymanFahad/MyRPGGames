using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackCooldown = 1.5f;
    [SerializeField] private float weaponRange = 0.6f;
    [SerializeField] private float knockbackForce = 10.0f;
    [SerializeField] private float knockbackTime = 0.15f;
    [SerializeField] private float stunTime = 1f;
    private float timer;
    public int damage = 2;

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
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, knockbackForce, knockbackTime, stunTime);
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
