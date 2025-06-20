using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Set up an interface to call actions from BuddyBots in range
public interface IBuddy
{
    Vector3 Position { get; } //Call from other scripts with "public Vector3 Position"
    void BuddyAction(); //Call from other scripts with "public void BuddyAction()"
}

public class CallBuddy : MonoBehaviour
{
    
}
