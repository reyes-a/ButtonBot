using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(0,-1,0), out RaycastHit contact, 1f))
        {
            print("Contact");
        }
        else
        {
            print("No contact");
        }
    }
}
