using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private void OnEnable()
    {
        SkillSlot.OnSkillPointSpent += handleSkillPointSpent;
    }

    private void OnDisable()
    {
        SkillSlot.OnSkillPointSpent -= handleSkillPointSpent;
    }

    private void handleSkillPointSpent(SkillSlot slot)
    {
        string skillName = slot.skillSO.skillName;
        switch (skillName)
        {
            case "Max Health Boost":
                PlayerStatsManager.instance.updateMaxHealth(1);
                break;

            default :
                Debug.LogWarning("The" + skillName +"skills didn't have case option yet");
                break;
        }
    }
}
