using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] Animator layoutAnimator;

    [SerializeField] GameObject settings_open;
    [SerializeField] GameObject settings_close;

    [SerializeField] GameObject sound_on;
    [SerializeField] GameObject sound_off;
    [SerializeField] GameObject iap;
    [SerializeField] GameObject information;

    [SerializeField] GameObject next_button;
    [SerializeField] GameObject rety_button;
    [SerializeField] GameObject FınishCamera;
    [SerializeField] GameObject FınishPlayer;
    [SerializeField] GameObject FınishPlayerLose;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject City;

    public static int level;
    private void Start()
    {   
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
    }

    public void Settings_Open()
    {
        settings_open.SetActive(false); 
        layoutgorupOpen();
        settings_close.SetActive(true);

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_on.SetActive(true);
            sound_off.SetActive(false);
            AudioListener.volume = 1;
        }

        if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_on.SetActive(false);
            sound_off.SetActive(true);
            AudioListener.volume = 0;
        }
    }

    public void Settings_Close()
    {
        settings_close.SetActive(false);
        layoutgorupClose();
        settings_open.SetActive(true);
    }

    public void Sound_On()
    {
        sound_on.SetActive(false);
        sound_off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }
    public void Sound_Off()
    {
        sound_on.SetActive(true);
        sound_off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }


    void layoutgorupOpen()
    {
        layoutAnimator.SetTrigger("Slider_in");
    }

    public void layoutgorupClose()
    {
        layoutAnimator.SetTrigger("Slider_out");
    }

    public void winArea()
    {
        next_button.SetActive(true);
        rety_button.SetActive(false);
        City.SetActive(true);
        Camera.SetActive(false);
        FınishCamera.SetActive(true);
        FınishPlayer.SetActive(true);
    }

    public void loseArea()
    {
        rety_button.SetActive(true);
        next_button.SetActive(false);
        City.SetActive(true);
        Camera.SetActive(false);
        FınishCamera.SetActive(true);
        FınishPlayerLose.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextGame()
    {
        level += 1;

        Debug.Log("level  " + level);

        SceneManager.LoadScene(level);       
    }

//    public void LoadTheLevel()
//    {
//        if (Player.level2 == 2)
//        {
//            levelGenerate = Random.Range(2, 6);
//            SceneManager.LoadScene(levelGenerate);
//        }
//    }
//
}