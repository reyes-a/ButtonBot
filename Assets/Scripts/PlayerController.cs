using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float minForce = 1f;
    [SerializeField] float maxForce = 100f;
    private float holdDuration;
    [SerializeField] float incrementValue = 0.1f;

    private bool isKeyDown = false;
    [SerializeField] bool contact = false;

    [SerializeField] Rigidbody rb; //It means rigidbody

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput(); //Calls the whole function

        //Check if player is touching the ground from all six faces
        if (Physics.Raycast(transform.position, transform.TransformDirection(0f, -0.2f, 0f), 0.5f) || 
            Physics.Raycast(transform.position, transform.TransformDirection(0f, 0.2f, 0f), 0.5f) ||
            Physics.Raycast(transform.position, transform.TransformDirection(-0.2f, 0f, 0f), 0.5f) ||
            Physics.Raycast(transform.position, transform.TransformDirection(0.2f, 0f, 0f), 0.5f) ||
            Physics.Raycast(transform.position, transform.TransformDirection(0f, 0f, -0.2f), 0.5f) ||
            Physics.Raycast(transform.position, transform.TransformDirection(0f, 0f, 0.2f), 0.5f))
        {
            contact = true;
            print("Contact");
        }
        else
        {
            contact = false;
            print("No contact");
        }

        if (isKeyDown == true)
        {
            holdDuration = Mathf.Clamp(holdDuration + (incrementValue * Time.deltaTime), 0f, 1f);
            print(holdDuration);

            if (holdDuration >= 1f)
            {
                isKeyDown = false;
                print("SHUT UP");
            }
        }
    }

    /// <summary>
    /// All the player movement stuff
    /// </summary>
    void MovementInput ()
    {
        //Check if player is on the ground
        if (contact == true)
        {
            print("On ground!");
            //Check if player wants to go forward (z)
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                holdDuration = 0f;
                isKeyDown = true;
            }
            //When player stops holding button, move
            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration);
                rb.AddForce(0, 0, force);
            }

            //(-z)
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                holdDuration = 0f;
                isKeyDown = true;
            }
            if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration);
                rb.AddForce(0, 0, -force);
            }

            //(-x)
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                holdDuration = 0f;
                isKeyDown = true;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration);
                rb.AddForce(-force, 0, 0);
            }

            //(x)
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                holdDuration = 0f;
                isKeyDown = true;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration);
                rb.AddForce(force, 0, 0);
            }
        }
    }
}
