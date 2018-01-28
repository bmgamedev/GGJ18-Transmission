using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public float Speed = 10.0f;
    public float Jump = 0.3f;
    public LayerMask GroundLayer;
    public bool doorOne;
    public bool doorTwo;
    public bool doorThree;
    //public bool doorFour;
    //public bool doorFive;
    public AudioClip jumpAudio;

    private Animator animator;
    private Transform groundCheck;
    private Rigidbody2D rb2d;
    private bool isGrounded;
    private string nextStartPos;
    private GameObject connectingDoor;
    private Vector3 defaultStartPos;
    static PlayerScript instance = null;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    private void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Win" || scene.name == "Captured" || scene.name == "OutOfTime")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        source = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        rb2d = GetComponent<Rigidbody2D>();

        doorOne = false;
        doorTwo = false;
        doorThree = false;
        //doorFour = false;
        //doorFive = false;

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Win" || scene.name == "Captured" || scene.name == "OutOfTime")
        {
            defaultStartPos = new Vector3(-4.58f, 0.78f, 0.0f);
            gameObject.transform.position = defaultStartPos;
        }
        else
        {
            defaultStartPos = gameObject.transform.position;
        }
    }

    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapPoint(groundCheck.position, GroundLayer);

        if (Input.GetButton("Jump"))
        {
            if (isGrounded)
            {
                source.PlayOneShot(jumpAudio);

                rb2d.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            }
        }

        animator.SetBool("isGrounded", isGrounded);

        float hSpeed = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(hSpeed));

        if (hSpeed > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (hSpeed < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(hSpeed * Speed, this.GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (isGrounded)
            {
                isGrounded = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Captured");
        }

        if (collision.GetComponent<Collider2D>().tag == "Door")
        {
            nextStartPos = SceneManager.GetActiveScene().name; 
            print(nextStartPos);
        }

        if (collision.gameObject.tag == "Key")
        {
            if (!doorOne)
            {
                doorOne = true;
            }
            else if (!doorTwo)
            {
                doorTwo = true;
            }

            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Captured");
        }

        
    }

    void OnLevelWasLoaded()
    {
        connectingDoor = (GameObject.Find(nextStartPos));

        if (connectingDoor)
        {
            print(nextStartPos + connectingDoor.transform.position);
            gameObject.transform.position = new Vector3(connectingDoor.transform.position.x, connectingDoor.transform.position.y, 0.0f);
        }
        else
        {
            print("no object to copy position of");
            gameObject.transform.position = defaultStartPos;
        }
    }



}