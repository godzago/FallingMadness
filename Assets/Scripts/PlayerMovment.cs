using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] CamerShake camershake;

    private Rigidbody rgb;
    private Touch touch;

    [SerializeField] float speed;
    [SerializeField] float ForwardSpeed;

    public bool f�rstTouchController;
    [SerializeField] GameManager gameManager;

    [SerializeField] GameObject LimitForwed;
    [SerializeField] GameObject LimitBack;

    [SerializeField] Slider mySlider;

    private Animator animator;

    [SerializeField] GameObject F�nishCamera;
    [SerializeField] GameObject F�nishPlayer;
    [SerializeField] GameObject F�nishPlayerLose;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject City;

    bool GameOver = false;
    void Start()
    {       
        rgb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        animator.enabled = false;
        Camera.SetActive(true);
        this.gameObject.SetActive(true);
    }    
    void FixedUpdate()
    {

        if (speed <= 100f && f�rstTouchController == true)
        {
            speed += 0.2f;
        }

        if (Input.touchCount > 0)       
        {
            touch = Input.GetTouch(0);

            animator.enabled = true;

            if (touch.phase == TouchPhase.Moved)
            {
                f�rstTouchController = true;
                Variables.FirstTouch = 1;
                rgb.velocity = new Vector3(touch.deltaPosition.x * ForwardSpeed * Time.deltaTime,
                                         transform.position.y,
                                         touch.deltaPosition.y * ForwardSpeed * Time.deltaTime);                      
            }
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            rgb.velocity = Vector3.zero;
        }
        else if (touch.phase == TouchPhase.Stationary)
        {
            rgb.velocity = Vector3.zero;
        }
    }

    private void Update()
    {
        SliderBar();

        if (Variables.FirstTouch == 1 && f�rstTouchController == true && GameOver == false)
        {                     
            gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);

            LimitForwed.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            LimitBack.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }   
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            speed -= 25f;
            camershake.CameraShakesCall();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (speed <= 100f)
            {
                f�rstTouchController = false;
                City.SetActive(true);
                Camera.SetActive(false);
                F�nishCamera.SetActive(true);
                F�nishPlayer.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                GameOver = true;
                f�rstTouchController = false;
                City.SetActive(true);
                Camera.SetActive(false);
                F�nishCamera.SetActive(true);
                F�nishPlayerLose.SetActive(true);
                this.gameObject.SetActive(false);       
            }
        }

        if (other.gameObject.CompareTag("puan"))
        {
            gameManager.ScoreManager();
        }
    }
    private void SliderBar()
    {
        mySlider.value = speed;
    }
}
