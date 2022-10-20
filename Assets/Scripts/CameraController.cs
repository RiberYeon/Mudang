using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject Player;
    
    void Start()
    {
        this.Player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 playerPos = this.Player.transform.position;
        transform.position = new Vector3(playerPos.x, playerPos.y, transform.position.z);
    }
}
