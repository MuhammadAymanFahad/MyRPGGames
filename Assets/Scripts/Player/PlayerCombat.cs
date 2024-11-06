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

            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);
            timer = attackCooldown;
        }
    }

    public void finishAttacking()
    {
        playerAnim.SetBool("isAttacking", false);
    }
}
