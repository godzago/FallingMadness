using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    private static BackgroundMusic backgroundMusic;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if(backgroundMusic == null)
        {
            backgroundMusic = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
