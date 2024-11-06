using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevationEntry : MonoBehaviour
{
    [SerializeField] private Collider2D[] highGroundColliders;
    [SerializeField] private Collider2D[] boundaryColliders;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Enemy")
        {
            foreach(Collider2D highGround in highGroundColliders)
            {
                highGround.enabled = false;
            }
            foreach (Collider2D boundary in boundaryColliders)
            {
                boundary.enabled = true;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 7;
        }

    }
}
