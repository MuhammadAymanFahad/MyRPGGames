using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            cameraFollow();
        }
        
    }

    void cameraFollow()
    {
        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        transform.position = new Vector3(playerX, playerY,transform.position.z);
    }
}
