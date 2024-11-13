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
        updateSkillPoints(0);
    }

    public void updateSkillPoints(int skillPoint)
    {
        availablePoints += skillPoint;
        pointsText.text = "Skill Points : " + skillPoint;
    }
}
