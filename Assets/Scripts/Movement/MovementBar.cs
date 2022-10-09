using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementBar : MonoBehaviour
{
    public Slider movementSlider;
    public Image movementFiller;

    public void SetMaxMovement(int movement)
    {
        movementSlider.maxValue = movement;
        movementSlider.value = movement;

    }

    public void SetMovement(int movement)
    {
        movementSlider.value = movement;
    }
}
