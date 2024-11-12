using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackCooldown = 1.5f;
    private float timer;
    

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
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, PlayerStatsManager.instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().changeHealth(-PlayerStatsManager.instance.damage);
            enemies[0].GetComponent<EnemyKnockback>().Knockback(transform, PlayerStatsManager.instance.knockbackForce, PlayerStatsManager.instance.knockbackTime, PlayerStatsManager.instance.stunTime);
        }
    }

    public void finishAttacking()
    {
        playerAnim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position,PlayerStatsManager.instance.weaponRange);
    }
}
