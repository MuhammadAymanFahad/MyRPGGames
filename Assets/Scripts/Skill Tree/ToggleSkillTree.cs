using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSkillTree : MonoBehaviour
{
    [SerializeField] CanvasGroup statsCanvas;
    private bool skillTreeOpen = false;

    // Update is called once per frame
    void Update()
    {
        toggleSkillCanvas();
    }

    void toggleSkillCanvas()
    {
        if (Input.GetButtonDown("ToggleSkills"))
        {
            if (skillTreeOpen)
            {
                statsCanvas.alpha = 0;
                statsCanvas.blocksRaycasts = false;
                skillTreeOpen = false;
            }
            else
            {
                statsCanvas.alpha = 1;
                statsCanvas.blocksRaycasts = true;
                skillTreeOpen = true;
            }
        }
    }
}
