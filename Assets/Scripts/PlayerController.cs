using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] //Organization!!! Life changing
    [SerializeField] float minForce = 150f;
    [SerializeField] float maxForce = 650f;
    private float holdDuration;
    [SerializeField] float incrementValue = 0.5f;
    private bool isKeyDown = false;
    [SerializeField] Rigidbody rb; //It means rigidbody

    [Header("Raycast")]
    [SerializeField] float raycastLength = 1.5f;
    private Vector3[] raycastDirections = new Vector3[] {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Way to see which way and how far the ray is going. Hide and unhide as necessary
        //Debug.DrawLine(transform.position, new Vector3(0f, 1.5f, 0f), Color.red); 

        MovementInput(); //Calls the whole function

        //Check how long the player holds the movement keys
        if (isKeyDown == true)
        {
            holdDuration = Mathf.Clamp(holdDuration + (incrementValue * Time.deltaTime), 0f, 1f);
            //print(holdDuration);

            if (holdDuration >= 1f)
            {
                isKeyDown = false;
                print("Movement Maximum");
            }
        }
    }

    /// <summary>
    /// All the player movement stuff
    /// </summary>
    void MovementInput ()
    {
            //Check if player wants to go forward (z) and is on ground
            if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && OnGroundCheck())
            {
                holdDuration = 0f;
                isKeyDown = true;
                GetComponentInChildren<ButtonPress>().ResetButton(); //Allow the button to be pressed again
            }
            //When player stops holding button, move
            if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && OnGroundCheck())
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration); //Local variable. Lerps are for guesstimation between values
                rb.AddForceAtPosition(new Vector3(0f, 0f, force), transform.position + new Vector3(0f, 1.5f, 0f)); //It wants a Vector3, and I have floats, so I have to make a new one
            }

            //(-z)
            if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && OnGroundCheck())
            {
                holdDuration = 0f;
                isKeyDown = true;
                GetComponentInChildren<ButtonPress>().ResetButton();
            }
            if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && OnGroundCheck())
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration);
                rb.AddForceAtPosition(new Vector3(0f, 0f, -force), transform.position + new Vector3(0f, 1.5f, 0f));
            }

            //(-x)
            if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && OnGroundCheck())
            {
                holdDuration = 0f;
                isKeyDown = true;
                GetComponentInChildren<ButtonPress>().ResetButton();
            }
            if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && OnGroundCheck())
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration);
                rb.AddForceAtPosition(new Vector3(-force, 0f, 0f), transform.position + new Vector3(0f, 1.5f, 0f));
            }

            //(x)
            if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && OnGroundCheck())
            {
                holdDuration = 0f;
                isKeyDown = true;
                GetComponentInChildren<ButtonPress>().ResetButton();
            }
            if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) && OnGroundCheck())
            {
                isKeyDown = false;
                float force = Mathf.Lerp(minForce, maxForce, holdDuration);
                rb.AddForceAtPosition(new Vector3(force, 0f, 0f), transform.position + new Vector3(0f, 1.5f, 0f));
            }
    }

    bool OnGroundCheck()
    {
        //Check if player is touching the ground from all six faces
        foreach (var direction in raycastDirections)
        {
            if (Physics.Raycast(transform.position, direction, raycastLength))
            {
                print("Contact");
                return true;
            }
        }
        //print("No contact");
        return false;
    }
}
