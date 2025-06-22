using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [Header("Button Function")]
    public bool shouldButtonActivate = true; //Need to stop the button from being pressed twice. Bugged for literally no reason???

    [Header("CallBuddy")]
    public float buddyRange = 20f;
    [SerializeField] GameObject rangeIndicator;
    float lerpScaleModifier = 0;
    [SerializeField] float rangeIndicatorScaleRate;
    [SerializeField] float rangeIndicatorHeight;
    bool doScaleRangeIndicatorIncrease = false;
    bool doScaleRangeIndicatorDecrease = false;
    [SerializeField] float rangeIndicatorScaleHesitate = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        rangeIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (doScaleRangeIndicatorIncrease)
        {
            ScaleRangeIndicatorIncrease();
        }
        if (doScaleRangeIndicatorDecrease)
        {
            ScaleRangeIndicatorDecrease();
        }
    }

    //When player lands on the button face, stop it from happening again until reset
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {

            //print("Trigger Enter");
            if (shouldButtonActivate == true)
            {
                shouldButtonActivate = false;
                StartIndicatorScaleIncrease();

                print("Button pressed!");
                CallBuddy();
            }
        } 
    }

    //Allow for the button to be pressed again
    public void ResetButton()
    {
        print("Reset");
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

    void StartIndicatorScaleIncrease()
    {
        rangeIndicator.SetActive(false);
        doScaleRangeIndicatorDecrease = false;
        rangeIndicator.transform.localScale = Vector3.one;
        rangeIndicator.transform.position = this.transform.position;
        rangeIndicator.SetActive(true);
        lerpScaleModifier = 0;
        doScaleRangeIndicatorIncrease = true;
    }

    void ScaleRangeIndicatorIncrease()
    {
        lerpScaleModifier += Mathf.Clamp01(rangeIndicatorScaleRate * Time.deltaTime);
        print("ScaleMod = " + lerpScaleModifier);
        var newScale = new Vector3(Mathf.Lerp(1, buddyRange, lerpScaleModifier), rangeIndicatorHeight, Mathf.Lerp(1, buddyRange, lerpScaleModifier));
        print("RangeIndicator newScale = " + newScale);
        rangeIndicator.transform.localScale = newScale;
        if (lerpScaleModifier >= 1) 
        { 
            doScaleRangeIndicatorIncrease = false;
            Invoke("StartIndicatorScaleDecrease", rangeIndicatorScaleHesitate); 
        }
    }

    void StartIndicatorScaleDecrease()
    {
        lerpScaleModifier = 1;
        doScaleRangeIndicatorDecrease = true;
    }

    void ScaleRangeIndicatorDecrease()
    {
        lerpScaleModifier -= Mathf.Clamp01(rangeIndicatorScaleRate * Time.deltaTime);
        print("ScaleMod Decrease = " + lerpScaleModifier);
        var newScale = new Vector3(Mathf.Lerp(1, buddyRange, lerpScaleModifier), rangeIndicatorHeight, Mathf.Lerp(1, buddyRange, lerpScaleModifier));
        print("RangeIndicator Decrease newScale = " + newScale);
        rangeIndicator.transform.localScale = newScale;
        if (lerpScaleModifier <= 0)
        {
            rangeIndicator.SetActive(false);
            doScaleRangeIndicatorDecrease = false;
        }
    }
}
