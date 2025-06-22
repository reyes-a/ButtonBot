using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollider : MonoBehaviour
{
    public bool isTouching = false;

    void OnCollisionEnter()
    {
        //print("We're trying");
        //print(name + " side trigger enter " + other.name);
        //if (!other.CompareTag("Player")) { print(name + " triggerEnter NOT PLAYER!!"); isTouching = true; }
        if (isTouching == false)
        {
            //print("No");
            isTouching = true;
            print("Contact");
        }        
    }

    private void OnCollisionExit()
    {
        //if (!other.CompareTag("Player")) { print(name + " triggerExit"); isTouching = false; }
    }
}
