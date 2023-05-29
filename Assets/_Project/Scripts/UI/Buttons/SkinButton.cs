using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkinButton : MonoBehaviour
{
    public CarData data;

    public TextMeshProUGUI carName;

    private void OnEnable()
    {
        Init(data);
    }

    public void Init(CarData newData)
    {
        data = newData;
        SetupView();
    }

    public void SetupView()
    {
        carName.text = data.carName;
    }

    public void OnClick()
    {
        Player.ChangeCar(data);
    }
}