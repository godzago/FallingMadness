using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] public Vector3 distance;
    [SerializeField] public float speed;
    private void LateUpdate()
    { 
        if (Variables.FirstTouch == 1)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position + distance, Time.deltaTime * speed);         
        }      
    }
    public void FixedUpdate()
    {
        speed += 0.01f;
    }
}
