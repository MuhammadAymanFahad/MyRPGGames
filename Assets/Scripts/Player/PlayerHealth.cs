using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Animator healthTextAnim;

    private void Start()
    {
        healthText.text = "HP : " + currentHealth + " / " + maxHealth;
    }

    
    public void changeHealth(int health)
    {
        currentHealth += health;
        healthTextAnim.Play("Text_Update");
        healthText.text = "HP : " + currentHealth + " / " + maxHealth;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
