using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 0.5f;
    private float translation;
    private float straffe;

    public GameObject Player;

    public int pickups = 0;

    public float jumpSpeed = 10.0f;
    public bool jumped;
    Collider coll;
    private bool isGrounded;

    public AudioSource pickupAudioSource;
    //public AudioSource goalAudioSource;

    void Start () {
        // turn off the cursor
        Cursor.lockState = CursorLockMode.Locked;	
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
	}
	
	// Update is called once per frame
	void Update () {

        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);

        jump();

        if (Input.GetKeyDown("escape")) {
            // turn on the cursor
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void jump() {
        // Jumping
        bool jpress = Input.GetKeyDown("space");

        if (jpress && !jumped && isGrounded) {
            jumped = true;
            print("Jumped");
            Vector3 jumpv = new Vector3(0f, jumpSpeed, 0f);
            //rb.velocity = rb.velocity + jumpv;
            rb.AddForce(jumpv * jumpSpeed, ForceMode.Impulse);
        }
        else if (jpress && !jumped && pickups > 0 && !isGrounded) {
            jumped = true;
            pickups -= 1;
            print("Double jumped");
            Vector3 jumpv = new Vector3(0f, jumpSpeed, 0f);
            //rb.velocity = rb.velocity + jumpv;
            rb.AddForce(jumpv * jumpSpeed, ForceMode.Impulse);
        }
        else {
            jumped = false;
        }
    }

    // For pickups
    void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Pickup") {
            print("Pickup!");
            pickupAudioSource.Play();
            pickups += 1;
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "Finish") {
            //goalAudioSource.Play();
            Destroy(collider.gameObject);
            //Application.Quit();

            //if (SceneManager.GetActiveScene().name == "Level1") {
            //SceneManager.LoadScene("LevelEnd");

            if (SceneManager.GetActiveScene().name == "Level1") {

                Cursor.visible = true;
                SceneManager.LoadScene("LevelEnd1");

            }
            if (SceneManager.GetActiveScene().name == "Level2") {

                Cursor.visible = true;
                SceneManager.LoadScene("LevelEnd2");

             }
             if (SceneManager.GetActiveScene().name == "Level3") {

                 Cursor.visible = true;
                SceneManager.LoadScene("LevelEnd3");

             }

            Cursor.lockState = CursorLockMode.None;

        }
    }

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.name == "Platform") {
            isGrounded = true;

            // moving platforms
            Player.transform.parent = col.transform;

        }
        if (col.gameObject.name == "Floor") {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    void OnCollisionExit(Collision col) {
        if (col.gameObject.name == "Platform") {
            isGrounded = false;
            // leave moving platform
            Player.transform.parent = null;
        }
    }

    /*
    void Update ()
    {
    MouseAiming();
    KeyboardMovement();
    }
 
    void MouseAiming ()
    {
    // get the mouse inputs
    float y = Input.GetAxis("Mouse X") * turnSpeed;
    rotX += Input.GetAxis("Mouse Y") * turnSpeed;
 
    // clamp the vertical rotation
    rotX = Mathf.Clamp(rotX, minTurnAngle, maxTurnAngle);
 
    // rotate the camera
    transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
    }
 
    void KeyboardMovement ()
    {
    Vector3 dir = new Vector3(0, 0, 0);
 
    dir.x = Input.GetAxis("Horizontal");
    dir.z = Input.GetAxis("Vertical");
 
    transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
    
    // Update is called once per frame
    void Update()
    {
        
        WalkHandler();

    }

    // Make the player walk according to user input
    void WalkHandler()
    {
        // Set x and z velocities to zero
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
 
        // Distance ( speed = distance / time --> distance = speed * time)
        float distance = walkSpeed * Time.deltaTime;
 
        // Input on x ("Horizontal")
        float hAxis = Input.GetAxis("Horizontal");
 
        // Input on z ("Vertical")
        float vAxis = Input.GetAxis("Vertical");
 
        // Movement vector
        Vector3 movement = new Vector3(hAxis * distance, 0f, vAxis * distance);
 
        // Current position
        Vector3 currPosition = transform.position;
 
        // New position
        Vector3 newPosition = currPosition + movement;
 
        // Move the rigid body
        rb.MovePosition(newPosition);
    }
    */

}
