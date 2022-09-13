using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] float score;
    private float LastScore;

    public void FixedUpdate()
    {
        if (playerMovment.fýrstTouchController == true && Variables.FirstTouch == 1)
        {
            score += 1 * Time.fixedDeltaTime;
        }

    }
    public void ScoreManager()
    {
        LastScore += 2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           score *= LastScore;

           Debug.Log("score " + score);
        }
    }
}


