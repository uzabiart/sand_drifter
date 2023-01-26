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
    //public EGameState state;
    public List<EPanelType> panelType;

    public Image img;
    public SpriteRenderer spr;
    public GameObject obj;

    public EObjectFadeType type;
    public float time;

    string animId;

    private void Awake()
    {
        animId = gameObject.GetInstanceID().ToString();
    }

    private void OnEnable()
    {
        UIEvents.OnPanelChanged += Manage;
    }
    private void OnDisable()
    {
        UIEvents.OnPanelChanged -= Manage;
    }

    private void Manage()
    {
        DOTween.Kill(animId);
        Debug.Log(GameData.Instance.CurrentPanel);
        if (panelType.Contains(GameData.Instance.CurrentPanel))
        {
            if (spr != null)
                if (type == EObjectFadeType.FadeIn)
                    spr.DOFade(1f, time).SetId(animId);
        }
        else
        {
            if (spr != null)
                if (type == EObjectFadeType.FadeIn)
                    spr.DOFade(0f, time).SetId(animId);
        }
    }
}