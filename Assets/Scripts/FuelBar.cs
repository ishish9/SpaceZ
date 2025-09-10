using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    private Slider slider;
    public float slidervalue;
    private float fuelLVL = 100f;

    void Start()
    {
        slider = GetComponent<Slider>();
        //slider.maxValue = fuelLVL;
        //SetFuelLevel(fuelLVL);
    }

    private void OnEnable()
    {
        FuelUpContainer.OnFuelup += AddFuel;
        Manager.OnResetFuel += ResetFuel;
    }

    private void OnDisable()
    {
        FuelUpContainer.OnFuelup -= AddFuel;
        Manager.OnResetFuel -= ResetFuel;
    }

    public void SetFuelLevel(float slidervalue)
    {
        slider.value = slidervalue;
    }

    public void AddFuel(float newValue)
    {
        slider.value += slidervalue + newValue;
    }

    public void ResetFuel()
    {
        slider.value = 100;
    }

}
