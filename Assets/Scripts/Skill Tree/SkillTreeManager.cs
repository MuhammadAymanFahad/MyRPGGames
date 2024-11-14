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
            slot.skillButton.onClick.AddListener(slot.tryUpgradeSkill);
        }
        Debug.Log("Available points :" + availablePoints);
        updateSkillPoints(0);
    }

    private void OnEnable()
    {
        SkillSlot.OnSkillPointSpent += handleSkillPointSpent;
        SkillSlot.OnSkillMaxed += handleSkillMaxed;
    }

    private void OnDisable()
    {
        SkillSlot.OnSkillPointSpent -= handleSkillPointSpent;
        SkillSlot.OnSkillMaxed -= handleSkillMaxed;
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
