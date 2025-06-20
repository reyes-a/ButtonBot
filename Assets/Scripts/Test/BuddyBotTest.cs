using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuddyBotTest : MonoBehaviour, IBuddy
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Find the buddies in the world
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
    }

    //When the interface is called, do this
    public void BuddyAction()
    {
        Destroy(this.gameObject);
    }
}
