using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 distance;
    private void LateUpdate()
    {
        if (Variables.FirstTouch == 1)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.fixedDeltaTime * 2);
        }       
    }
}
