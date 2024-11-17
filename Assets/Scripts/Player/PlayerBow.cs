using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    private float shootTimer;
    [SerializeField] private float shootCooldown = 1f;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private GameObject arrowPrefabs;
    private Vector2 aimDirection = Vector2.right;

    private void Update()
    {
        shootTimer -= Time.deltaTime;
        handleAiming();
        if(shootTimer <= 0)
        {
            shoot();
        }
    }

    public void shoot()
    {
        if (Input.GetButtonDown("ShootArrow"))
        {
            Arrow arrow = Instantiate(arrowPrefabs, launchPoint.position, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = aimDirection;
            shootTimer = shootCooldown;
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
