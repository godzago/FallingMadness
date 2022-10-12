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
    [SerializeField] GameObject LiveScore;

    public void OnTriggerEnter(Collider other)
    {
        if (Variables.StartScne == 0)
        {
            startCamera.SetActive(false);
            Cameras.SetActive(true);
            StartPlayer.SetActive(false);
            startUI.SetActive(false);           
            SliderGameObject.SetActive(true);
            LiveScore.SetActive(true);
            Variables.StartScne = 1;
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
