using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class MenuCamera : MonoBehaviour
{
    public CinemachineVirtualCamera cinemachine;
    CinemachineTransposer cTransporter;
    public Transform camPivot;
    public Transform camTransform;

    public CameraAnimationInfo[] camPositions;
    public CameraAnimationInfo currentAnimation;

    public SpriteInfo[] disableForShop;

    private void Awake()
    {
        cTransporter = cinemachine.GetCinemachineComponent<CinemachineTransposer>();
    }

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
        foreach (CameraAnimationInfo info in camPositions)
            if (info.type == GameData.Instance.CurrentPanel)
                currentAnimation = info;

        if (GameData.Instance.CurrentPanel == EPanelType.Skins)
            AnimateSkinsPanel();
        if (GameData.Instance.CurrentPanel == EPanelType.Gameplay)
            AnimateGameplayView();
        if (GameData.Instance.CurrentPanel == EPanelType.Menu)
            AnimateMenuView();
    }

    private void AnimateCam()
    {
        camTransform.DOLocalMove(currentAnimation.camPosition, currentAnimation.animationSpeed).SetId("MenuUI").SetEase(Ease.InOutCubic);
        camPivot.DORotate(currentAnimation.camRotation, currentAnimation.animationSpeed).SetId("MenuUI").SetEase(Ease.InOutCubic);
        DOTween.To(() => cTransporter.m_ZDamping, x => cTransporter.m_ZDamping = x, currentAnimation.followSpeed, currentAnimation.animationSpeed).SetEase(Ease.OutCubic).SetId("MenuUI");
    }

    private void AnimateMenuView()
    {
        DOTween.Kill("MenuUI");
        DOTween.To(() => QualitySettings.shadowDistance, x => QualitySettings.shadowDistance = x, 66f, 0.6f).SetEase(Ease.Linear).SetId("MenuUI");

        AnimateCam();

        //DOTween.To(() => followTarget.followSpeed, x => followTarget.followSpeed = x, 0.4f, 0.6f).SetEase(Ease.OutCubic).SetId("MenuUI").OnComplete(() =>
        //{
        //    foreach (SpriteInfo spr in disableForShop) spr.spr.DOFade(spr.alpha, 1.6f).SetEase(Ease.OutCubic).SetId("MenuUI");
        //});
    }

    private void AnimateGameplayView()
    {
        DOTween.Kill("MenuUI");
        DOTween.To(() => QualitySettings.shadowDistance, x => QualitySettings.shadowDistance = x, 66f, 0.6f).SetEase(Ease.Linear).SetId("MenuUI");

        AnimateCam();

        //foreach (SpriteInfo spr in disableForShop) spr.spr.DOFade(spr.alpha, 1.6f).SetEase(Ease.OutCubic).SetId("MenuUI");
        //DOTween.To(() => followTarget.followSpeed, x => followTarget.followSpeed = x, 0.4f, 0.6f).SetEase(Ease.OutCubic).SetId("MenuUI").OnComplete(() =>
        //{
        //});
    }

    private void AnimateSkinsPanel()
    {
        DOTween.Kill("MenuUI");
        //foreach (SpriteInfo spr in disableForShop) spr.spr.DOFade(0f, 0.2f).SetId("MenuUI");

        DOTween.To(() => QualitySettings.shadowDistance, x => QualitySettings.shadowDistance = x, 7f, 0.6f).SetEase(Ease.Linear).SetId("MenuUI");

        AnimateCam();

        //DOTween.To(() => followTarget.followSpeed, x => followTarget.followSpeed = x, 0f, 0.6f).SetEase(Ease.OutCubic).SetId("MenuUI").OnComplete(() =>
        //{
        //});
    }
}

[System.Serializable]
public class SpriteInfo
{
    public SpriteRenderer spr;
    public float alpha;
}

[System.Serializable]
public class CameraAnimationInfo
{
    public EPanelType type;
    public Vector3 camPosition;
    public Vector3 camRotation;
    public float followSpeed;
    public float animationSpeed;
}