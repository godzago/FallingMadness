using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartEpisote : MonoBehaviour
{
    [SerializeField] GameObject Cameras;
    [SerializeField] GameObject startCamera;
    [SerializeField] GameObject StartPlayer;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject SliderGameObject;
    [SerializeField] bool Startepisode;
    [SerializeField] GameObject LiveScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("Game") == false)
        {
            PlayerPrefs.SetInt("Game", 1);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (Startepisode == false)
        {
            startCamera.SetActive(false);
            Cameras.SetActive(true);
            StartPlayer.SetActive(false);
            startUI.SetActive(false);
            Startepisode = true;
            SliderGameObject.SetActive(true);            
            PlayerPrefs.SetInt("Game", 2);
        }
        else
        {
            startCamera.SetActive(false);
            Cameras.SetActive(true);
            StartPlayer.SetActive(false);
            startUI.SetActive(false);         
        }
    }
    public void startepisode()
    {
        startCamera.SetActive(false);
        Cameras.SetActive(true);
        StartPlayer.SetActive(false);
        startUI.SetActive(false);
        SliderGameObject.SetActive(true);
        LiveScore.SetActive(true);
    }
}
