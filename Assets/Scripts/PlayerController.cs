using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float minForce = 1f;
    [SerializeField] float maxForce = 100f;

    [SerializeField] Rigidbody rb; //It means rigidbody

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player wants to go forward (z)
        if ( Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) )
        {
            rb.AddForce(0,0,maxForce);
        }
        //Check if player wants to go back (-z)
        if ( Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) )
        {
            rb.AddForce(0,0,-maxForce);
        } 
        //Check if player wants to go left (-x)
        if ( Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            rb.AddForce(-maxForce,0,0);
        }
        //Check if player wants to go right (x)
        if ( Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) )
        {
            rb.AddForce(maxForce,0,0);
        }
    }
}
