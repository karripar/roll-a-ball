using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
 // Reference to the player GameObject.
 public GameObject player;

 private Vector3 offset;

 void Start()
    {
        offset = transform.position - player.transform.position; 
    }

 void LateUpdate()
    {
        transform.position = player.transform.position + offset;  
    }
}