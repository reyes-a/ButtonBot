using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BuddyMove_Rotate : MonoBehaviour, IBuddy
{
    [Header("Design: Rotation Directions")]
    [SerializeField] Vector3[] Rotations;
    int rotationsIndex = 0;
    bool doRotateToTarget = false;
    Vector3 startRot;
    Vector3 targetRot;
    /// <summary>
    /// Value that the movement lerp value increments each tick
    /// </summary>
    [SerializeField] float rateOfRotation = 0.1f;
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
        if (doRotateToTarget)
        {
            RotateToTarget();
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

    //What do I want it to do? Find value of index and pass to function... compare to the length of the list and get it to start over when it's done
    public void BuddyAction()
    {
        if (rotationsIndex > (Rotations.Length - 1))
        {
            print("Reset Loop");
            rotationsIndex = 0;
        }
        StartRotateToTarget();
        rotationsIndex++;
    }

    void StartRotateToTarget()
    {
        startRot = transform.rotation.eulerAngles;
        targetRot = Rotations[rotationsIndex] + startRot;
        lerpMovementValue = 0;
        doRotateToTarget = true;
        print(this.gameObject.name + " - Starting rotate to with index: " + rotationsIndex);
    }

    void RotateToTarget()
    {
        lerpMovementValue += Mathf.Clamp01(rateOfRotation * Time.fixedDeltaTime); // calculate new lerp value
        //transform.rotation =  new Quaternion(Mathf.Lerp(startRot.x, targetRot.x, lerpMovementValue), Mathf.Lerp(startRot.y, targetRot.y, lerpMovementValue), Mathf.Lerp(startRot.z, targetRot.z, lerpMovementValue), 5.91348e-43f);
        print(this.gameObject.name + " lerp value = " + lerpMovementValue);
        //transform.Rotate(Vector3.Lerp(startRot, targetRot, lerpMovementValue), Space.Self);
        transform.localRotation = Quaternion.Euler (Vector3.Lerp(startRot, targetRot, lerpMovementValue));
        if (lerpMovementValue >= 1) { doRotateToTarget = false; } // if target pos reached, stop movement
    }
}
