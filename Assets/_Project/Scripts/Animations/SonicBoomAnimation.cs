using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins.Options;
using Sirenix.OdinInspector;

public class SonicBoomAnimation : MonoBehaviour
{
    public Material boomMaterial;
    public Vector2 startTiling;
    public Vector2 endTiling;

    public Vector3 startScale;
    public Vector3 endScale;

    public float delay;
    string animationId;

    private void Awake()
    {
        animationId = gameObject.GetInstanceID() + "sonic_boom_animation";
    }

    private void OnEnable()
    {
        Animate();
    }

    [Button]
    private void Animate()
    {
        StopAllCoroutines();
        StartCoroutine(AnimationTask());
    }

    public IEnumerator AnimationTask()
    {
        yield return new WaitForSeconds(delay);
        DOTween.Kill(animationId);
        boomMaterial.mainTextureScale = startTiling;
        transform.localPosition = Vector3.zero;
        transform.localScale = startScale;
        boomMaterial.DOTiling(endTiling, 0.15f).SetEase(Ease.Linear).SetId(animationId);
        transform.DOScale(endScale, 0.6f);
        yield return new WaitForSeconds(0.15f);
        transform.DOLocalMoveZ(-20, 0.3f).SetEase(Ease.Linear).SetId(animationId);
        //yield return new WaitForSeconds(0.2f);
        //StartCoroutine(AnimationTask());
    }
}