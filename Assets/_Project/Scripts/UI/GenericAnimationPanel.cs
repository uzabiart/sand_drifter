using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GenericAnimationPanel : MonoBehaviour
{
    public EPanelType type;
    public AnimatedObject[] animatedObjects;
    int i = 0;

    public void Show()
    {
        gameObject.SetActive(true);
        for (i = 0; i < animatedObjects.Length; i++)
        {
            animatedObjects[i].obj.localPosition = animatedObjects[i].show.startPosition;
            animatedObjects[i].obj.DOLocalMove(animatedObjects[i].show.endPosition, animatedObjects[i].show.duration).SetEase(animatedObjects[i].show.ease);
        }
    }

    public void Hide()
    {
        if (!gameObject.activeSelf) return;

        for (i = 0; i < animatedObjects.Length; i++)
        {
            animatedObjects[i].obj.localPosition = animatedObjects[i].hide.startPosition;
            animatedObjects[i].obj.DOLocalMove(animatedObjects[i].hide.endPosition, animatedObjects[i].hide.duration).SetEase(animatedObjects[i].hide.ease).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}

[System.Serializable]
public class AnimatedObject
{
    public Transform obj;
    public AnimationInfo show;
    public AnimationInfo hide;
}

[System.Serializable]
public class AnimationInfo
{
    public float duration;
    public Ease ease;
    public Vector3 startPosition;
    public Vector3 endPosition;
}