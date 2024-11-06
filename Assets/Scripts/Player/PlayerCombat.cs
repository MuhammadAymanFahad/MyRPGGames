using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator playerAnim;
    [SerializeField] private float attackCooldown;
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

    public void finishAttacking()
    {
        playerAnim.SetBool("isAttacking", false);
    }
}
