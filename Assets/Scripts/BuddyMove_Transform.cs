using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuddyMove_Transform : MonoBehaviour, IBuddy
{
    [Header("Design: Movement Directions")]
    [SerializeField] Vector3[] MoveDirections;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Where is it?
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }

    //What do I want it to do?
    public void BuddyAction()
    {
        print("Moved!");
    }
}
