using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] float score;
    private int LastScore;
    public bool twoXtake;

    public void FixedUpdate()
    {
        if (playerMovment.fýrstTouchController == true && Variables.FirstTouch == 1)
        {
           score += 2 * Time.fixedDeltaTime;
        }

    }
    public void ScoreManager()
    {
        LastScore += 2;
        twoXtake = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            if (twoXtake == true)
            {
                score *= LastScore;

                Debug.Log("score " + score);
            }
            else
            {
                Debug.Log("2x almamýs score " + score);
            }
        }
    }
}


