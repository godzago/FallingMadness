using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] float score;


    private void FixedUpdate()
    {
        score += 1 * Time.deltaTime ; 
    }
}
