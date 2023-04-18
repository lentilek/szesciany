using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f; //public so it appears in unity and sets basic speed to 5
    private float normalSpeed;
    public float boostedSpeed;
    public float speedCoolDown;

    public Rigidbody rb; //initialize Rigidbody component

    public bool cubeIsOnTheGround = true; //bool = returned as TRUE or FALSE; to check if floor is on the ground 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //references to the rigidbody comp
    }

    void Update()
    {
        normalSpeed = speed;
        //MOVING MECHANIC HERE//
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed; //time.deltaTime so it updates once per second
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontal, 0, vertical); //can move on X and Z axis, not up and down on the Y

        // JUMPING MECHANIC HERE //
        //jump key = space in the input >> project manager >> InputManager 
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround) //&& = AND operator
        {
            SoundManagerScript.PlaySound("jumpsound"); // powinno wtedy wydawa� d�wi�k skoku -martyna
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse); //on each frame it adds this value of Y to the cube
            cubeIsOnTheGround = false; //whenever we press SPACE cube ISNT on the ground
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
            speed = boostedSpeed;
            StartCoroutine("SpeedDuration");
        }
        if (other.CompareTag("JumpPad"))
        {
            rb.AddForce(new Vector3(0, 20, 0), ForceMode.Impulse);
        }


    }

    IEnumerator SpeedDuration() //allows you to time something, do something after a certain amount of time
    {
        yield return new WaitForSeconds(speedCoolDown); //its basically saying to this and go into here, wait for an amount of seconds set and then to this
        speed = 7f;
    }




}
