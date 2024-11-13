using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerExpManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    private float expToLevelMultiplier = 1.2f;
    [SerializeField] private TMP_Text currentLevelText;


    public void gainExperience(int exp)
    {
        currentExp += exp;
        if(currentExp >= expToLevel)
        {
            levelUp();
        }
    }

    private void levelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expToLevelMultiplier);
    }
}
