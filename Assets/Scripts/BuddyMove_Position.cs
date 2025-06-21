using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuddyMove_Position : MonoBehaviour, IBuddy
{
    [Header("Design: Movement Directions")]
    [SerializeField] Vector3[] MovementPositions;
    public int currentPos = 0;


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
        if (currentPos <= (MovementPositions.Length - 1))
        {
            //print(currentPos);
            transform.position = MovementPositions[currentPos];
            print("Moved! " + currentPos);
            currentPos++;
            //print(currentPos);
        }
        else
        {
            print("Reset Loop");
            currentPos = 0;
            transform.position = MovementPositions[currentPos];
            print("Moved! " + currentPos);
            currentPos++;
        }
    }
}

