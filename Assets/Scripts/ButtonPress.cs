using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [Header("Button Function")]
    public bool isPressed = false;
    public bool shouldButtonActivate = true; //Need to stop the button from being pressed twice

    [Header("CallBuddy")]
    public float buddyRange = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When player lands on the button face, stop it from happening again until reset
    void OnTriggerEnter(Collider other)
    {
        if (shouldButtonActivate == true)
        {
            isPressed = true;
            shouldButtonActivate = false;
            print("Button pressed!");
            CallBuddy();
        }
    }

    //Allow for the button to be pressed again
    public void ResetButton()
    {
        isPressed = false;
        shouldButtonActivate = true;
    }

    //Use the overlap sphere to detect colliders. If it's a buddy in range, have it send a message
    public void CallBuddy()
    {
        Collider[] buddyColliders = Physics.OverlapSphere(transform.position, buddyRange);
        foreach (Collider buddy in buddyColliders)
        {
            if (buddy.GetComponent<IBuddy>() != null)
            {
                print("Buddy!");
                buddy.GetComponent<IBuddy>().BuddyAction();
            }
        }
    }
}
