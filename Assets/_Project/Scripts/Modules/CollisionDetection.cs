using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionDetection : MonoBehaviour
{
    public Car car;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            ApplySpeedBoost();
        }
    }

    private void ApplySpeedBoost()
    {
        DOTween.Kill("SpeedBoost");
        car.currentSpeed = car.defaultSpeed * 4;

        DOTween.To(() => car.currentSpeed, x => car.currentSpeed = x, car.defaultSpeed, 6f).SetEase(Ease.InExpo).SetId("SpeedBoost");
    }
}