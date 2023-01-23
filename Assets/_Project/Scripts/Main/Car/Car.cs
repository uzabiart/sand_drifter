using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float defaultSpeed;
    public float currentSpeed;

    private void Awake()
    {
        currentSpeed = defaultSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
    }
}