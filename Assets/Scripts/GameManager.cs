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
    [SerializeField] Text live_score;

    public static float Puan;
    private int scoreint;
    private int live_score_int;

    [SerializeField] ParticleSystem particlesystem;
    private void Start()
    {
        particlesystem.Stop();
    }

    public void FixedUpdate()
    {
        if (playerMovment.fýrstTouchController == true && Variables.FirstTouch == 1)
        {
           score += 2 * Time.fixedDeltaTime;
        }

       live_score_int = Mathf.RoundToInt(score);

        live_score.text = live_score_int.ToString();
    }

    public void ScoreManager()
    {
        LastScore += 1;
        twoXtake = true;
        particlesystem.Play();       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
                if(twoXtake == true)
                score *= LastScore;             
                else
                Puan += score;

                scoreint = Mathf.RoundToInt(Puan);

                text_score.text = scoreint.ToString();                

                Puan += score;

                scoreint = Mathf.RoundToInt(Puan);

                text_score.text = scoreint.ToString();
        }       
    }
}