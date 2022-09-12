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

    private bool fýrstTouchController;

    [SerializeField] GameObject LimitForwed;
    [SerializeField] GameObject LimitBack;

    [SerializeField] Slider mySlider;

    private Animator animator;

    [SerializeField] GameObject FýnishCamera;
    [SerializeField] GameObject FýnishPlayer;
    [SerializeField] GameObject FýnishPlayerLose;
    [SerializeField] GameObject Camera;

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
        if (speed <= 100f && fýrstTouchController == true)
        {
            speed += 0.2f;
        }

        if (Input.touchCount > 0)       
        {
            touch = Input.GetTouch(0);
            
            if (touch.phase == TouchPhase.Began)
            {
                animator.enabled = true;
            }

            if (touch.phase == TouchPhase.Moved)
            {              
                rgb.velocity = new Vector3(touch.deltaPosition.x * ForwardSpeed * Time.deltaTime,
                                         transform.position.y,
                                         touch.deltaPosition.y * ForwardSpeed * Time.deltaTime);
                Variables.FirstTouch = 1;
                fýrstTouchController = true;
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


        if (Variables.FirstTouch == 1 && fýrstTouchController == true && GameOver == false)
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
                Camera.SetActive(false);
                FýnishCamera.SetActive(true);
                FýnishPlayer.SetActive(true);
                this.gameObject.SetActive(false);
            }
            else
            {
                Camera.SetActive(false);
                FýnishCamera.SetActive(true);
                FýnishPlayerLose.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
    private void SliderBar()
    {
        mySlider.value = speed;
    }
}
