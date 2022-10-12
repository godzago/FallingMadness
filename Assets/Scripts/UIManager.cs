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
    [SerializeField] int levelGenerate;
    [SerializeField] GameObject live_score;
    [SerializeField] GameObject currentPlayer;

    [SerializeField] GameObject sliderBar;

    [SerializeField] ParticleSystem fireParticle;
    [SerializeField] ParticleSystem ScorParticle;

    private void Start()
    {   
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        currentPlayer.SetActive(true);
        fireParticle.Stop();
        fireParticle.Stop();
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
            AudioListener.volume = 0.5f;
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
        AudioListener.volume = 0.5f;
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
        currentPlayer.SetActive(false);
        next_button.SetActive(true);
        rety_button.SetActive(false);
        City.SetActive(true);
        Camera.SetActive(false);
        FınishCamera.SetActive(true);
        FınishPlayer.SetActive(true);
        live_score.SetActive(false);
        sliderBar.SetActive(false);
        Invoke("fireParticleFucation", 2f);
    }

    public void loseArea()
    {
        currentPlayer.SetActive(false);
        rety_button.SetActive(true);
        next_button.SetActive(false);
        City.SetActive(true);
        Camera.SetActive(false);
        FınishCamera.SetActive(true);
        FınishPlayerLose.SetActive(true);
        live_score.SetActive(false);
        sliderBar.SetActive(false);
        GameManager.Puan = 0;
        Invoke("ScorParticleFucation", 2f);
    }
    public void fireParticleFucation()
    {
        fireParticle.Play();
        ScorParticle.Play();
    }
    public void ScorParticleFucation()
    {
        ScorParticle.Play();
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void NextGame()
    {
        if (Variables.Level == 4)
        {
            levelGenerate = Random.Range(0, 4);
            SceneManager.LoadScene(levelGenerate);
        }
        else
        {
            Variables.Level += 1;

            SceneManager.LoadScene(Variables.Level);
        }           
    }
}
