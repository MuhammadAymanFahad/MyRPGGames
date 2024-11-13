using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlot : MonoBehaviour
{
    public SkillSO skillSO;

    public int currentLevel;
    public bool isUnlocked;

    public Image skillIcon;
    public TMP_Text skillLevelText;

    private void OnValidate()
    {
        if(skillSO != null && skillLevelText != null)
        {
            updateUI();
        }
    }

    private void updateUI()
    {
        skillIcon.sprite = skillSO.skillIcon;
        if (isUnlocked)
        {
            skillLevelText.text = currentLevel.ToString() + "/" + skillSO.maxLevel.ToString();
            skillIcon.color = Color.white;
        }
        else
        {
            skillLevelText.text = "Locked";
            skillIcon.color = Color.grey;
        }
    }
}
