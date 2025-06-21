using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BuddyMove_Position : MonoBehaviour, IBuddy
{
    [Header("Design: Movement Directions")]
    [SerializeField] Vector3[] MovementPositions;
    int movementPosIndex = 0;
    bool doMoveToTarget = false;
    Vector3 startPos;
    Vector3 targetPos;
    /// <summary>
    /// Value that the movement lerp value increments each tick
    /// </summary>
    [SerializeField] float rateOfMovement = 0.1f;
    float lerpMovementValue = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (doMoveToTarget)
        {
            MoveToTarget();
        }
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
        //print("Moved!");
        if (movementPosIndex > (MovementPositions.Length - 1))
        {
            print("Reset Loop");
            movementPosIndex = 0;
        }
        StartMoveToTarget();
        movementPosIndex++;
    }

    void StartMoveToTarget()
    {
        startPos = transform.position;
        targetPos = MovementPositions[movementPosIndex];
        lerpMovementValue = 0;
        doMoveToTarget = true;
        print("Starting move to with index: " + movementPosIndex);
    }

    void MoveToTarget()
    {
        lerpMovementValue += Mathf.Clamp01(rateOfMovement * Time.fixedDeltaTime); // calculate new lerp value
        transform.position = new Vector3(Mathf.Lerp(startPos.x, targetPos.x, lerpMovementValue), Mathf.Lerp(startPos.y, targetPos.y, lerpMovementValue), Mathf.Lerp(startPos.z, targetPos.z, lerpMovementValue));
        if (lerpMovementValue == 1) { doMoveToTarget = false; } // if target pos reached, stop movement
    }
}

