using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerExpManager : MonoBehaviour
{
    public int level = 1;
    public int currentExp;
    public int expToLevel = 10;
    private float expToLevelMultiplier = 1.2f;
    [SerializeField] private Slider expSlider;
    [SerializeField] private TMP_Text currentLevelText;

    public static event Action<int> onLevelUp;

    private void Start()
    {
        updateLevelSlider();
    }

    private void OnEnable()
    {
        EnemyHealth.onMonsterDefeated += gainExperience;
    }

    private void OnDisable()
    {
        EnemyHealth.onMonsterDefeated -= gainExperience;
    }

    private void updateLevelSlider()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level : " + level;
    }

    public void gainExperience(int exp)
    {
        currentExp += exp;
        if(currentExp >= expToLevel)
        {
            levelUp();
        }
        updateLevelSlider();
    }

    private void levelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expToLevelMultiplier);
        onLevelUp?.Invoke(1);
    }
}
