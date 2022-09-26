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

    static float Puan;
    private int scoreint;
    private int live_score_int;

    [SerializeField] ParticleSystem particlesystem;
    private void Awake()
    {
        particlesystem.Stop();
    }

    private void Start()
    {
        //PlayerPrefs.GetFloat("totatScore", Puan);
    }

    public void FixedUpdate()
    {
        if (playerMovment.f�rstTouchController == true && Variables.FirstTouch == 1)
        {
           score += 2 * Time.fixedDeltaTime;
        }

        live_score_int = Mathf.RoundToInt(score);

        live_score.text = live_score_int.ToString();
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

               // scoreint = Mathf.RoundToInt(Puan);
                
               // text_score.text = scoreint.ToString();


                Puan += score;

                scoreint = Mathf.RoundToInt(Puan);

                text_score.text = scoreint.ToString();                

                //PlayerPrefs.SetFloat("totatScore", Puan);

                Debug.Log("score " + score);
            }
            else
            {
                Debug.Log("2x almam�s score " + score);
            }
        }       
    }
}


