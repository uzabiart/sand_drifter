using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public enum EObjectFadeType
{
    Default = 0,
    FadeIn = 10,
}

public class EnableAtState : MonoBehaviour
{
    public EGameState state;

    public Image img;
    public SpriteRenderer spr;
    public GameObject obj;

    public EObjectFadeType type;
    public float time;

    private void OnEnable()
    {
        GameEvents.OnGameStateChange += Manage;
    }
    private void OnDisable()
    {
        GameEvents.OnGameStateChange -= Manage;
    }

    private void Manage()
    {
        if (state != GameData.Instance.CurrentGameState)
        {
            if (spr != null)
                if (type == EObjectFadeType.FadeIn)
                    spr.DOFade(0f, time);
        }
        else
        {
            if (spr != null)
                if (type == EObjectFadeType.FadeIn)
                    spr.DOFade(1f, time);
        }
    }
}