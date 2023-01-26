using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuCamera : MonoBehaviour
{
    public Transform camOffset;
    public FollowTarget followTarget;
    public Vector3 shopPos;
    public Vector3 shopRotation;
    public Vector3 gameplayPos;
    public Vector3 gameplayRotation;

    public SpriteInfo[] disableForShop;

    private void OnEnable()
    {
        UIEvents.OnPanelChanged += ManagePanel;
    }
    private void OnDisable()
    {
        UIEvents.OnPanelChanged -= ManagePanel;
    }

    void ManagePanel()
    {
        if (GameData.Instance.CurrentPanel == EPanelType.Skins)
            AnimateSkinsPanel();
        if (GameData.Instance.CurrentPanel == EPanelType.Gameplay ||
            GameData.Instance.CurrentPanel == EPanelType.Menu)
            AnimateGameplayView();
    }

    private void AnimateGameplayView()
    {
        DOTween.Kill("MenuUI");
        followTarget.x = false;
        followTarget.y = true;
        followTarget.z = true;
        DOTween.To(() => QualitySettings.shadowDistance, x => QualitySettings.shadowDistance = x, 66f, 0.6f).SetEase(Ease.Linear).SetId("MenuUI");

        transform.DORotate(gameplayRotation, 1f).SetId("MenuUI");
        camOffset.DOLocalMove(gameplayPos, 0.6f).SetId("MenuUI");
        DOTween.To(() => followTarget.followSpeed, x => followTarget.followSpeed = x, 0.4f, 0.6f).SetEase(Ease.OutCubic).SetId("MenuUI").OnComplete(() =>
        {
            foreach (SpriteInfo spr in disableForShop) spr.spr.DOFade(spr.alpha, 1.6f).SetEase(Ease.OutCubic).SetId("MenuUI");
        });
    }

    private void AnimateSkinsPanel()
    {
        DOTween.Kill("MenuUI");
        foreach (SpriteInfo spr in disableForShop) spr.spr.DOFade(0f, 0.2f).SetId("MenuUI");

        followTarget.x = true;
        followTarget.y = true;
        followTarget.z = true;

        DOTween.To(() => QualitySettings.shadowDistance, x => QualitySettings.shadowDistance = x, 7f, 0.6f).SetEase(Ease.Linear).SetId("MenuUI");
        transform.DORotate(shopRotation, 1f).SetId("MenuUI");
        camOffset.DOLocalMove(shopPos, 0.6f).SetId("MenuUI");
        DOTween.To(() => followTarget.followSpeed, x => followTarget.followSpeed = x, 0f, 0.6f).SetEase(Ease.OutCubic).SetId("MenuUI").OnComplete(() =>
        {
            followTarget.enabled = false;
            followTarget.enabled = true;
        });
    }
}

[System.Serializable]
public class SpriteInfo
{
    public SpriteRenderer spr;
    public float alpha;
}