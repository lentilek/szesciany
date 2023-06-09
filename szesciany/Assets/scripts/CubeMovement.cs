using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class CubeMovement : MonoBehaviour
{
    public float speed1; //public so it appears in unity and sets basic speed to 5
    private float normalSpeed;
    public float boostedSpeed;
    public float speedCoolDown;
    public float jumpPad;

    //do dasha
    public float dash;
    public GameObject DashDestroy;
    private float dashTime = 0.5f;
    private bool isDashing = false;
    private int dashMax = 3;
    private int dashCounter = 0;
    public TextMeshProUGUI dashUI;

    public float speed2 = 0.5f; // speed in air
    public Rigidbody rb; //initialize Rigidbody component

    public bool cubeIsOnTheGround = true; //bool = returned as TRUE or FALSE; to check if floor is on the ground 
    public float jumpForce = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //references to the rigidbody comp
        normalSpeed = speed1;
        dashUI.text = dashCounter.ToString();
    }

    void Update()
    {
        
        //MOVING MECHANIC HERE//

       //transform.Translate(horizontal, 0, vertical); //can move on X and Z axis, not up and down on the Y

        // JUMPING MECHANIC HERE //
        //jump key = space in the input >> project manager >> InputManager 
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround) //&& = AND operator
        {
            SoundManagerScript.PlaySound("jumpsound"); // powinno wtedy wydawa� d�wi�k skoku -martyna
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); //on each frame it adds this value of Y to the cube
            cubeIsOnTheGround = false; //whenever we press SPACE cube ISNT on the ground
        }
        //dash
        if (Input.GetKeyDown(KeyCode.C) && dashCounter < dashMax)
        {
            rb.AddForce(new Vector3(0, 0, dash), ForceMode.Impulse);
            isDashing = true;
            dashCounter++;
            dashUI.text = dashCounter.ToString();
            StartCoroutine(DashTime());
        }
    }
    IEnumerator DashTime()
    {
        yield return new WaitForSeconds(dashTime);
        isDashing= false;
    }

    private void FixedUpdate()
    {
        if (cubeIsOnTheGround) // change speed if in air
        {
            float horizontal = Input.GetAxis("Horizontal") * speed1; //time.deltaTime so it updates once per second
            float vertical = Input.GetAxis("Vertical") * speed1;
            rb.AddForce( new Vector3(horizontal, 0, vertical), ForceMode.VelocityChange); 
        }
        else
        {
            float horizontal = Input.GetAxis("Horizontal") * speed2; //time.deltaTime so it updates once per second
            float vertical = Input.GetAxis("Vertical") * speed2;
            rb.AddForce(new Vector3(horizontal, 0, vertical), ForceMode.VelocityChange);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") //we're checking if we're on the floor (checks the TAG not the NAME) coz if yes then we can jump if we're not on the floor (like in mid air) we can't press space to jump
        {
            cubeIsOnTheGround = true; //so the jump only works ONCE and we can't keep pressing space in mid-air
        }
    }

    /*private void OnCollisionEnter(Collider hit)
    {
        switch (hit.gameObject.tag)
        {
            case "SpeedBoost":
                speed = 150f;
                break;
            //case "Ground":
                //speed = 5f;
                //break;
        }
    }
    */
    

    //tag comparison
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            speed1 = boostedSpeed;
            StartCoroutine(SpeedDuration());
        }
        if (other.CompareTag("JumpPad"))
        {
            rb.AddForce(new Vector3(0, jumpPad, 0), ForceMode.Impulse);
            SoundManagerScript.PlaySound("jumpPadsound");
        }
        /*if (other.CompareTag("Dash"))
        {
            Destroy(DashDestroy);
        }*/
        if (isDashing && other.CompareTag("Destroy"))
        {
            DashDestroy.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (isDashing && other.CompareTag("Destroy"))
        {
            DashDestroy.SetActive(false);
        }
    }

    IEnumerator SpeedDuration() //allows you to time something, do something after a certain amount of time
    {
        yield return new WaitForSeconds(speedCoolDown); //its basically saying to this and go into here, wait for an amount of seconds set and then to this
        speed1 = normalSpeed;
    }
    





}
