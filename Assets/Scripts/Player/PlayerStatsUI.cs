using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private GameObject[] statsSlot;
    [SerializeField] public CanvasGroup statsCanvas;
    private bool statsOpen = false;

    private void Start()
    {
        updateAllStats();
    }

    private void Update()
    {
        if (Input.GetButtonDown("ToggleStats"))
        {
            if (statsOpen)
            {
                Time.timeScale = 1;
                statsCanvas.alpha = 0;
                statsOpen = false;
            }
            else
            {
                Time.timeScale = 0;
                statsCanvas.alpha = 1;
                statsOpen = true;
            }
        }    
    }

    public void updateAllStats()
    {
        statsSlot[0].GetComponentInChildren<TMP_Text>().text = "Damage : " + PlayerStatsManager.instance.damage;
        statsSlot[1].GetComponentInChildren<TMP_Text>().text = "Speed : " + PlayerStatsManager.instance.speed;
    }


}
