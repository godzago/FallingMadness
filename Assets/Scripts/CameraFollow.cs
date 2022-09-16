using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 distance;
    private void LateUpdate()
    { 
        if (Variables.FirstTouch == 1)
        {
            transform.position = target.position + distance;
        }      
    }
}
