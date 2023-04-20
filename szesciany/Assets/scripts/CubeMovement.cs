using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CubeMovement : MonoBehaviour
{
    public float speed1 = 5f; //public so it appears in unity and sets basic speed to 5
    public float speed2 = 0.5f; // speed in air
    public Rigidbody rb; //initialize Rigidbody component
    public bool cubeIsOnTheGround = true; //bool = returned as TRUE or FALSE; to check if floor is on the ground 
    public float jumpForce = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //references to the rigidbody comp
    }

    void Update()
    {
        //MOVING MECHANIC HERE//

       //transform.Translate(horizontal, 0, vertical); //can move on X and Z axis, not up and down on the Y

        // JUMPING MECHANIC HERE //
        //jump key = space in the input >> project manager >> InputManager 
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround) //&& = AND operator
        {
            SoundManagerScript.PlaySound("jumpsound"); // powinno wtedy wydawaæ dŸwiêk skoku -martyna
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); //on each frame it adds this value of Y to the cube
            cubeIsOnTheGround = false; //whenever we press SPACE cube ISNT on the ground
        }
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
}
