using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerMovment playerMovment;
    [SerializeField] float score;
    private int LastScore;
    [SerializeField] public bool twoXtake;

    [SerializeField] Text text_score;
    private int Puan;
    private int scoreint;

    [SerializeField] ParticleSystem particlesystem;
    private void Awake()
    {
        particlesystem.Stop();
    }

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
        particlesystem.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {          
            if (twoXtake == true)
            {

                score *= LastScore;

                Debug.Log("score " + score);

                scoreint = Mathf.RoundToInt(score);

                text_score.text = scoreint.ToString();

                PlayerPrefs.SetFloat("TotalScore", score);
            }
            else
            {
                Debug.Log("2x almamýs score " + score);
            }
        }       
    }
}


