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
            Arrow arrow = Instantiate(arrowPrefabs, launchPoint.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = aimDirection;
        }
    }

    private void handleAiming()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            aimDirection = new Vector2(horizontal, vertical).normalized;
        }
    }
}
