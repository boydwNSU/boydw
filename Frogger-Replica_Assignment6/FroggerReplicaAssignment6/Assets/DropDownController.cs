using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownController : MonoBehaviour
{

    public Dropdown CarSpeedDropDown;
    public Dropdown CarSpawnSpeedDropDown;
    public Dropdown CarSizeDropDown;
    public Dropdown FrogSizeDropDown;

    public Text CarSpeedText;
    public Text CarSpawnSpeedText;
    public Text CarSizeText;
    public Text FrogSizeText;

    public static float carSpeed = 8f;
    public static float carSpawnSpeed = .3f;
    public static float carSizeMultiplier = 1f;
    public static float frogSizeMultiplier = 1f;

    // Update is called once per frame
    void Update()
    {
        switch (CarSpeedDropDown.value)
        {
            case 1:
                carSpeed = 8f;
                break;
            case 2:
                carSpeed = 10f;
                break;
            case 3:
                carSpeed = 14f;
                break;
            default:
                carSpeed = 8f;
                break;
        }

        switch(CarSpawnSpeedDropDown.value)
        {
            case 1:
                carSpawnSpeed = .7f;
                break;
            case 2:
                carSpawnSpeed = .5f;
                break;
            case 3:
                carSpawnSpeed = .3f;
                break;
            default:
                carSpawnSpeed = .3f;
                break;
        }

        switch(CarSizeDropDown.value)
        {
            case 1:
                carSizeMultiplier = .5f;
                 break;
            case 2:
                carSizeMultiplier = .75f;
                break;
            case 3:
                carSizeMultiplier = 1f;
                break;
            default:
                carSizeMultiplier = 1f;
                break;     
        }
        switch (FrogSizeDropDown.value)
        {
            case 1:
                frogSizeMultiplier = .5f;
                break;
            case 2:
                frogSizeMultiplier = .75f;
                break;
            case 3:
                frogSizeMultiplier = 1f;
                break;
            default:
                frogSizeMultiplier = 1f;
                break;
        }

        CarSpeedText.text = "Car Speed\n" + carSpeed.ToString();
        CarSpawnSpeedText.text = "Car Spawn Speed\n" + carSpawnSpeed.ToString();
        CarSizeText.text = "Car Size\n" + carSizeMultiplier.ToString();
        FrogSizeText.text = "Frog Size\n" + frogSizeMultiplier.ToString();
    }
}
