using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCollider : MonoBehaviour
{
    public bool isTouching = false;

    private void OnTriggerEnter(Collider other)
    {
        print(name + " side trigger enter " + other.name);
        if (!other.CompareTag("Player")) { print(name + " triggerEnter NOT PLAYER!!"); isTouching = true; }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) { print(name + " triggerExit"); isTouching = false; }
    }
}
