using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UMI/Cars/New Car")]
public class CarData : ScriptableObject
{
    public string carName;
    public GameObject model;
    public CarStats stats;
}

[System.Serializable]
public class CarStats
{
    public Speed speed;
}

[System.Serializable]
public class Speed
{
    public MinMaxCurrent value;
    public int boost;
}

[System.Serializable]
public struct MinMaxCurrent
{
    public int min;
    public int current;
    public int max;
}