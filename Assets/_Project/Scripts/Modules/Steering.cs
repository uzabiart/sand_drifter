using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Steering : MonoBehaviour
{
    public Transform entity;
    public Ease ease;

    Vector2 clickInput;
    bool steering;
    float steerPos;

    public float steeringRange;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SaveClickInput();
        if (Input.GetMouseButtonUp(0))
            StopSteer();

        if (steering) Steer();
    }

    private void Steer()
    {
        steerPos = steeringRange * ((Input.mousePosition.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f));
        entity.transform.DOLocalMoveX(steerPos, 1f).SetEase(ease);
        //entity.transform.localPosition = new Vector3(steerPos, entity.localPosition.y, entity.localPosition.z);
    }

    void SaveClickInput()
    {
        clickInput = Input.mousePosition;
        steering = true;
    }
    void StopSteer()
    {
        steering = false;
    }
}