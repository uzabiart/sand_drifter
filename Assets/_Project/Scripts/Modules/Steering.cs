using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Steering : MonoBehaviour
{
    public Transform entity;
    public Transform view;
    public Car car;
    public Ease ease;
    public Ease animationEase;

    Vector2 clickInput;
    bool steering;
    float steerPos;

    public float steeringRange;

    private void Update()
    {
        if (GameData.Instance.CurrentGameState != EGameState.Gameplay) return;

        if (Input.GetMouseButtonDown(0))
            SaveClickInput();
        if (Input.GetMouseButtonUp(0))
            StopSteer();

        if (steering) Steer();
        Animate();
    }

    private void Animate()
    {
        float diff = steerPos - entity.transform.localPosition.x;
        float speed = ((car.currentSpeed - car.defaultSpeed) * 0.02f);
        GameData.Instance.localPlayer.UpdateGforce(Mathf.Abs(diff));
        view.DOLocalRotate(new Vector3(Math.Abs(diff * 2f + diff * speed), diff * 2f + diff * speed, diff * -20f + diff * speed), 0.2f).SetEase(animationEase);
    }

    private void Steer()
    {
        if (GameData.Instance.localPlayer.state == ECarState.Dead) return;

        steerPos = steeringRange * ((Input.mousePosition.x - (Screen.width * 0.5f)) / (Screen.width * 0.5f));

#if UNITY_EDITOR
        //steerPos *= 2.2f;
#else
        steerPos *= 2.2f;
#endif

        entity.transform.DOLocalMoveX(steerPos, 1f).SetEase(ease);
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