using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject arrowPrefabs;
    private Vector2 aimDirection = Vector2.right;

    private void Update()
    {
        handleAiming();
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

    private void handleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
    }
}
