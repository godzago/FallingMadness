using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoved : MonoBehaviour
{
    [SerializeField] Transform firstPos, secondPos;
    [SerializeField] float speed;

    Vector3 nextPos;

    private void Start()
    {
        nextPos = firstPos.position;    }

    private void FixedUpdate()
    {
        if(transform.position == firstPos.position)

            nextPos = secondPos.position;

        if(transform.position == secondPos.position)
            nextPos = firstPos.position;

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firstPos.position, secondPos.position);
    }
}
