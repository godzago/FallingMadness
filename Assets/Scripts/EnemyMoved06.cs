using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoved06 : MonoBehaviour
{
    [SerializeField] Transform firstPos, secondPos;
    [SerializeField] float speed;

    Vector3 nextPos;

    [SerializeField] ParticleSystem particle;
    private void Start()
    {
        nextPos = firstPos.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == firstPos.position)
        {
            transform.rotation = Quaternion.Euler(0, 180, -90);
            nextPos = secondPos.position;
        }

        if (transform.position == secondPos.position)
        {
            transform.rotation = Quaternion.Euler(0, 180, 90);
            nextPos = firstPos.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            particle.transform.position = gameObject.transform.position;
            particle.Play();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(firstPos.position, secondPos.position);
    }
}
