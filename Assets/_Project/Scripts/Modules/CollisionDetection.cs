using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollisionDetection : MonoBehaviour
{
    public Car car;
    int obstacles = 0;
    ObstacleScore score;
    float distance = 0f;
    float savedDistance = 500f;
    float savedGforce = 0f;
    int savedMultiply;
    Collider curObstacle;

    public AudioClip speedBoost;
    public AnnouncerInfo speedBoostAnnouncer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
            ApplySpeedBoost();
        if (other.CompareTag("Obstacle"))
            ObstacleLogic(other);
        if (other.CompareTag("Collision"))
            ShipCollision();
    }

    private void ShipCollision()
    {
        car.Dead();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Obstacle"))
            FinishObstacleScore();
    }

    private void FinishObstacleScore()
    {
        obstacles--;
        if (obstacles == 0)
        {
            score.gforce = savedGforce;
            score.dist = savedDistance;
            score.multiply = savedMultiply;
            GameplayEvents.OnObstacleScore?.Invoke(score);
            savedDistance = 500;
            savedGforce = 0;
            savedMultiply = 0;
        }
    }

    private void ObstacleLogic(Collider obstacle)
    {
        curObstacle = obstacle;
        savedMultiply++;
        obstacles++;
        //distance = Mathf.Sqrt((transform.position - obstacle.transform.position).sqrMagnitude);
        //score = new ObstacleScore(GameData.Instance.localPlayer.gforce, distance);
        //float distance2 = Vector3.Distance(transform.position, obstacle.transform.position);
        //Debug.Log($"OBSTACLE: {distance}, {GameData.Instance.localPlayer.gforce}");
    }

    private void Update()
    {
        if (obstacles > 0)
        {
            CountObstacleScore();
        }
    }
    void CountObstacleScore()
    {
        distance = Mathf.Sqrt((transform.position - curObstacle.transform.position).sqrMagnitude);
        if (distance < savedDistance) savedDistance = distance;
        if (GameData.Instance.localPlayer.gforce > savedGforce) savedGforce = GameData.Instance.localPlayer.gforce;

    }

    private void ApplySpeedBoost()
    {
        DOTween.Kill("SpeedBoost");
        car.currentSpeed = car.defaultSpeed * 4;

        GameEvents.OnSfx?.Invoke(speedBoost, 0.6f);
        GameEvents.OnAnnouncer?.Invoke(speedBoostAnnouncer);

        DOTween.To(() => car.currentSpeed, x => car.currentSpeed = x, car.defaultSpeed * 2, 0.8f).SetEase(Ease.OutCubic).SetId("SpeedBoost").OnComplete(() =>
        {
            DOTween.To(() => car.currentSpeed, x => car.currentSpeed = x, car.defaultSpeed, 6f).SetEase(Ease.InExpo).SetId("SpeedBoost");
        });
        GameData.Instance.localPlayer.OnGainedBoost?.Invoke();
    }
}

[System.Serializable]
public struct ObstacleScore
{
    public float gforce;
    public float dist;
    public int multiply;
}