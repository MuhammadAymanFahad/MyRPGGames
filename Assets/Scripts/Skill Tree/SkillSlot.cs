using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    public List<SkillSlot> prequisiteSkillSlots;
    public SkillSO skillSO;

    public int currentLevel;
    public bool isUnlocked;

    public Image skillIcon;
    public Button skillButton;
    public TMP_Text skillLevelText;

    public static event Action<SkillSlot> OnSkillPointSpent;
    public static event Action<SkillSlot> OnSkillMaxed;

    private void OnValidate()
    {
        if(skillSO != null && skillLevelText != null)
        {
            updateUI();
        }
    }

    public void tryUpgradeSkill()
    {
        if(isUnlocked && currentLevel < skillSO.maxLevel)
        {
            currentLevel++;
            OnSkillPointSpent?.Invoke(this);
            if (currentLevel >= skillSO.maxLevel)
            {
                OnSkillMaxed?.Invoke(this);
            }
            updateUI();
        }
    }

    public bool canUnlockSkill()
    {
        foreach (SkillSlot slot in prequisiteSkillSlots)
        {
            /*
            if (slot == null)
            {
                Debug.LogError("Prerequisite Skill is null!");
                return false;
            }
            */
            if (!slot.isUnlocked || slot.currentLevel < slot.skillSO.maxLevel)
            {
                return false;
            }
        }
        return true;
    }

    public void unlock()
    {
        isUnlocked = true;
        updateUI();
    }

    private void updateUI()
    {
        skillIcon.sprite = skillSO.skillIcon;
        if (isUnlocked)
        {
            skillButton.interactable = true;
            skillLevelText.text = currentLevel.ToString() + "/" + skillSO.maxLevel.ToString();
            skillIcon.color = Color.white;
        }
        else
        {
            skillButton.interactable = false;
            skillLevelText.text = "Locked";
            skillIcon.color = Color.grey;
        }
    }
}
