using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform PlayerTransform;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = PlayerTransform.position.x;
        pos.y = PlayerTransform.position.y;
        transform.position = pos;
    }
}
