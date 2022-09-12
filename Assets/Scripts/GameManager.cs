using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] float score;

    public void FixedUpdate()
    {
        if (playerMovment.fýrstTouchController == true && Variables.FirstTouch == 1)
        {
            score += 1 * Time.fixedDeltaTime;
        }

    }

    public void ScoreManager()
    {
        score *= 1.15f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(score);
        }
    }
}


