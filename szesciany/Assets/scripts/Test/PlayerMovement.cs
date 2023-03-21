using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; //public so it appears in unity and sets basic speed to 5
    public Rigidbody rb; //initialize Rigidbody component
    public bool cubeIsOnTheGround = true; //bool = returned as TRUE or FALSE; to check if floor is on the ground 


    [Header("Picking")]
    public Camera PlayerCam;
    public bool Picked;
    public float pickedSpeed;

    private Vector3 pickVelocity;
    public GameObject pickedObject;

    public Transform pickPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); //references to the rigidbody comp
    }

    void Update()

    {
        //pickup mechanic
        Vector3 origin = PlayerCam.transform.position;
        Vector3 dir = PlayerCam.transform.forward;

        RaycastHit hit;
        Ray forwardRay = new Ray(origin, dir);

        if (Physics.Raycast(forwardRay, out hit, Vector3.Distance(Camera.main.transform.position, pickPos.transform.position)))
        {
            if (hit.transform.tag == "Pickable")
            {
                pickedObject = hit.transform.gameObject;
                Picked = true;
            }

            else
            {
                pickedObject = null;
                Picked = false;
            }

        }

        if (Input.GetMouseButtonDown(0) && Picked && pickedObject != null)
        {
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;

            Vector3 toPos = pickPos.transform.position - pickedObject.transform.position;

            rb.velocity = toPos;
            rb.velocity *= pickedSpeed;

            if (Input.GetKey(KeyCode.R))
            {
                pickedObject.transform.rotation = Quaternion.identity;
            }
        }

        //MOVING MECHANIC HERE//
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * speed; //time.deltaTime so it updates once per second
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(horizontal, 0, vertical); //can move on X and Z axis, not up and down on the Y

        // JUMPING MECHANIC HERE //
        //jump key = space in the input >> project manager >> InputManager 
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround) //&& = AND operator
        {
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
}
