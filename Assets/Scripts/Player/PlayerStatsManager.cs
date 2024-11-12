using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour
{
    [Header("Combat Stats")]
    public int weaponRange;
    public int knockbackForce;
    public int knockbackTime;
    public int stunTime;

    [Header("Movement Stats")]
    public int speed;

    [Header("Heath Stats")]
    public int maxHealth;
    public int currentHealth;
}
