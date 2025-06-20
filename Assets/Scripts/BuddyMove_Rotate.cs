using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BuddyMove_Rotate : MonoBehaviour, IBuddy
{
    [Header("Design: Rotation Directions")]
    [SerializeField] Vector3[] Rotations;
    public int currentRotation = 0;

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

    //What do I want it to do? Find value of index and pass to function... compare to the length of the list and get it to start over when it's done
    public void BuddyAction()
    {
        if (currentRotation <= (Rotations.Length - 1))
        {
           // print(currentRotation);
            transform.Rotate(Rotations[currentRotation]);
            print("Rotated! " + currentRotation);
            currentRotation ++;
           // print(currentRotation);
        }
        else
        {
            print("No rotation");
        }
    }
}
