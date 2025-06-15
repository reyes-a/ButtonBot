using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")] //Organization!!! Life changing
    [SerializeField] float minForce = 1f;
    [SerializeField] float maxForce = 100f;
    private float holdDuration;
    [SerializeField] float incrementValue = 0.1f;
    private bool isKeyDown = false;
    [SerializeField] Rigidbody rb; //It means rigidbody

    [Header("Raycast")]
    [SerializeField] float raycastLength = 0.6f;
    private Vector3[] raycastDirections = new Vector3[] {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput(); //Calls the whole function

        if (isKeyDown == true)
        {
            holdDuration = Mathf.Clamp(holdDuration + (incrementValue * Time.deltaTime), 0f, 1f);
            print(holdDuration);

            if (holdDuration >= 1f)
            {
                isKeyDown = false;
                print("SHUT UP"); // so rude :,<
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
        }
        //When player stops holding button, move
        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && OnGroundCheck()) // potential for bug with OnGroundCheck here if moved by other force
        {
            isKeyDown = false;
            float force = Mathf.Lerp(minForce, maxForce, holdDuration);
            //Vector3 forceVector = new Vector3(0, 1, force);
            //var convertedForce = transform.InverseTransformDirection(forceVector);
            //var downVector = GetCurrentLocalDownVector();
            //var rotatedForce = Quaternion.AngleAxis(90, convertedForce) * downVector;
            //rb.AddRelativeForce(convertedForce);
            ////rb.AddRelativeForce(0, 1, force);

            var downVector = GetCurrentLocalDownVector();
            print("down dir: " + downVector);
            var convertedRotationAxis = transform.InverseTransformDirection(-transform.right);
            var forceDir = Quaternion.AngleAxis(90, convertedRotationAxis) * downVector;
            var forceToApply = force * forceDir;
            print("force dir: " + forceDir);
            print(forceToApply);
            rb.AddRelativeForce(forceToApply);



        }

        //(-z)
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && OnGroundCheck())
        {
            holdDuration = 0f;
            isKeyDown = true;
        }
        if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) && OnGroundCheck())
        {
            isKeyDown = false;
            float force = Mathf.Lerp(minForce, maxForce, holdDuration);
            var convertedForce = transform.InverseTransformDirection(0, 1, -force);
            rb.AddRelativeForce(convertedForce);
            //rb.AddForce(0, 1, -force);
            //rb.AddRelativeForce(0, 1, -force);

        }

        //(-x)
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && OnGroundCheck())
        {
                holdDuration = 0f;
                isKeyDown = true;
        }
        if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) && OnGroundCheck())
        {
            isKeyDown = false;
            float force = Mathf.Lerp(minForce, maxForce, holdDuration);
            var convertedForce = transform.InverseTransformDirection(-force, 1, 0);
            rb.AddRelativeForce(convertedForce);
            //rb.AddRelativeForce(-force, 1, 0);
            //rb.AddForce(-force, 1, 0);
        }

        //(x)
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && OnGroundCheck())
        {
            holdDuration = 0f;
            isKeyDown = true;
        }
        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) && OnGroundCheck())
        {
            isKeyDown = false;
            float force = Mathf.Lerp(minForce, maxForce, holdDuration);
            var convertedForce = transform.InverseTransformDirection(force, 1, 0);
            
            rb.AddRelativeForce(convertedForce);
            //rb.AddRelativeForce(force, 1, 0);
            //rb.AddForce(force, 1, 0);
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
        return false;
    }

    Vector3 GetCurrentLocalDownVector()
    {
        foreach (var direction in raycastDirections)
        { // ITS GETTING ME THE WORLD DOWN VECTOR >:(
            if (Physics.Raycast(transform.localPosition, direction, raycastLength))
            {
                //print("Contact");
                return direction;
            }
        }
        return Vector3.zero;
    }
}
