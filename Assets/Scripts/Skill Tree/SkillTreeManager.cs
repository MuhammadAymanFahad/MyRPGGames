using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillTreeManager : MonoBehaviour
{
    public SkillSlot[] skillSlots;
    public TMP_Text pointsText;
    public int availablePoints;

    private void Start()
    {
        foreach (SkillSlot slot in skillSlots)
        {
            slot.skillButton.onClick.AddListener(() => checkAvailablePoints(slot));
        }
        updateSkillPoints(0);
    }

    private void checkAvailablePoints(SkillSlot slot)
    {
        if (availablePoints > 0)
        {
            slot.tryUpgradeSkill();
        }
    }

    private void OnEnable()
    {
        SkillSlot.OnSkillPointSpent += handleSkillPointSpent;
        SkillSlot.OnSkillMaxed += handleSkillMaxed;
        PlayerExpManager.onLevelUp += updateSkillPoints;
    }

    private void OnDisable()
    {
        SkillSlot.OnSkillPointSpent -= handleSkillPointSpent;
        SkillSlot.OnSkillMaxed -= handleSkillMaxed;
        PlayerExpManager.onLevelUp -= updateSkillPoints;
    }

    public void updateSkillPoints(int skillPoint)
    {
        availablePoints += skillPoint;
        pointsText.text = "Skill Points : " + availablePoints;
    }

    private void handleSkillPointSpent(SkillSlot skillSlot)
    {
        if(availablePoints > 0)
        {
            updateSkillPoints(-1);   
        }
    }

    private void handleSkillMaxed(SkillSlot skillSlot)
    {
        foreach(SkillSlot slot in skillSlots)
        {
            if(!slot.isUnlocked && slot.canUnlockSkill())
            {
                slot.unlock();
            }
        }
    }
}
