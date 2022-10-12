using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    void LateUpdate()
    {
        if (Variables.FirstTouch == 1)
        {
            transform.position = target.position + offset;
        }
    }
}
