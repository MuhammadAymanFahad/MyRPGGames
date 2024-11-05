using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;

    public void changeHealth(int health)
    {
        currentHealth += health;

        if(currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
