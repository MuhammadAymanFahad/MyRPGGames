using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float currentHeath;
    [SerializeField] private float maxHealth;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated onMonsterDefeated;
    public int expReward;
 
    private void Start()
    {
        currentHeath = maxHealth;
    }

    public void changeHealth(int health)
    {
        currentHeath += health;
        if(currentHeath > maxHealth)
        {
            currentHeath = maxHealth;
        }
        else if (currentHeath <= 0)
        {
            onMonsterDefeated(expReward);
            Destroy(this.gameObject);
        }
    }
}
