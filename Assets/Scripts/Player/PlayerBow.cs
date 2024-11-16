using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject arrowPrefabs;

    private void Update()
    {
        shoot();
    }

    public void shoot()
    {
        if (Input.GetButtonDown("ShootArrow"))
        {
            Debug.Log("shoot button pressed");
            Instantiate(arrowPrefabs, launchPoint.position, Quaternion.identity);
        }
    }
}
