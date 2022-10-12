using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovment : MonoBehaviour
{
    private Rigidbody rgb;
    private Touch touch;

    [SerializeField] float speed;
    [SerializeField] float ForwardSpeed;

    public bool fýrstTouchController;
    [SerializeField] GameManager gameManager;
    [SerializeField] UIManager UImanager;

    [SerializeField] GameObject LimitForwed;
    [SerializeField] GameObject LimitBack;

    public Slider mySlider;
    public float maxDistance;
    public GameObject finisLine;
    public Transform myCharactertransform;

    private Animator animator;

    [SerializeField] GameObject Camera;

    bool GameOver = false;

    [SerializeField] StartEpisote start_scene;

    [SerializeField] ParticleSystem particl1;
    void Start()
    {
        rgb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        animator.enabled = false;
        this.gameObject.SetActive(true);

        if (Variables.StartScne == 1) 
        {
            start_scene.startepisode();
            Camera.SetActive(true);
        }
    }

    private void FixedUpdate()
    {       
        if (speed <= 150f && fýrstTouchController == true)
        {
            speed += 0.15f;
            var emission = particl1.emission;
            emission.rateOverTime = speed / 2;
        }
    }
    void Update()
    {
        if (Input.touchCount > 0)       
        {           
            touch = Input.GetTouch(0);

            animator.enabled = true;
            if (touch.phase == TouchPhase.Moved)
            {            
                fýrstTouchController = true;
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

        if (Variables.FirstTouch == 1 && fýrstTouchController == true && GameOver == false)
        {
            gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            LimitForwed.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            LimitBack.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        float distance = finisLine.transform.position.z - myCharactertransform.transform.position.z;
        mySlider.value = 1 - (distance / maxDistance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Controller"))
        {
            if (speed <= 80f)
            {
                UImanager.winArea();
                fýrstTouchController = false;
                this.gameObject.SetActive(false);
            }
            else
            {
                UImanager.loseArea();
                GameOver = true;
                fýrstTouchController = false;
                this.gameObject.SetActive(false);       
            }
        }

        if (other.gameObject.CompareTag("puan"))
        {
            gameManager.ScoreManager();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            speed -= 20f;
        }
    }
}
