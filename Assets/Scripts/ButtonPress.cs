using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [Header("Button Function")]
    public bool isPressed = false;
    public bool shouldButtonActivate = true; //Need to stop the button from being pressed twice

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Do these things
        if (isPressed == true)
        {
            //Stuff
        }
    }

    //When player lands on the button face, stop it from happening again until reset
    void OnTriggerEnter(Collider other)
    {
        isPressed = true;
        shouldButtonActivate = false;
        print("Button pressed!");
    }

    //Allow for the button to be pressed again
    public void ResetButton()
    {
        isPressed = false;
        shouldButtonActivate = true;
    }
}
