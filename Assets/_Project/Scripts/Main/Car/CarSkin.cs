using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSkin : MonoBehaviour
{
    public Transform parent;
    public GameObject currentCar;

    private void OnEnable()
    {
        GameplayEvents.OnChangeCar += UpdateSkin;
    }
    private void OnDisable()
    {
        GameplayEvents.OnChangeCar -= UpdateSkin;
    }

    public void UpdateSkin()
    {
        if (currentCar != null) Destroy(currentCar);

        currentCar = Instantiate(Player.GetCar().model, parent);
    }
}