using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
}

public static class Player
{
    public static CarData GetCar()
    {
        return GameData.Instance.localPlayer.currentCar;
    }
    public static void ChangeCar(CarData newCar)
    {
        GameData.Instance.localPlayer.ChangeCar(newCar);
    }
}