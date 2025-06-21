using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveChargeUI : MonoBehaviour
{
    public float hold, maxHold, width, height;

    [SerializeField]
    private RectTransform moveChargeBar;

    public void SetMaxHold(float MaxHold)
    {
        maxHold = MaxHold;
    }

    public void SetHold(float Hold)
    {
        hold = Hold;
        float newHeight = (hold / maxHold) * height;

        moveChargeBar.sizeDelta = new Vector2(width, newHeight);
    }
}
