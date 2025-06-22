using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoveChargeUI : MonoBehaviour
{
    [Header("UI")]
    public float hold = 0f;
    public float maxHold = 1f;
    public float barWidth = 30f;
    public float barHeight = 100f;
    [SerializeField] RectTransform moveChargeBar;

    void Start()
    {
        
    }

    public void SetHold(float currentCharge)
    {
        currentCharge = Mathf.Lerp(hold, barHeight, currentCharge);

        moveChargeBar.sizeDelta = new Vector2(barWidth, currentCharge);
    }
}
