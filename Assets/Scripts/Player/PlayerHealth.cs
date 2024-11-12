using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Animator healthTextAnim;

    private void Start()
    {
        healthText.text = "HP : " + PlayerStatsManager.instance.currentHealth + " / " + PlayerStatsManager.instance.maxHealth;
    }

    
    public void changeHealth(int health)
    {
        PlayerStatsManager.instance.currentHealth += health;
        healthTextAnim.Play("Text_Update");
        healthText.text = "HP : " + PlayerStatsManager.instance.currentHealth + " / " + PlayerStatsManager.instance.maxHealth;

        if (PlayerStatsManager.instance.currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
