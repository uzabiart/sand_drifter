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
            animatedObjects[i].obj.localPosition = animatedObjects[i].hidePosition;
            animatedObjects[i].obj.DOLocalMove(animatedObjects[i].showPosition, animatedObjects[i].show.duration).SetEase(animatedObjects[i].show.ease);
        }
    }

    public void Hide()
    {
        if (!gameObject.activeSelf) return;

        for (i = 0; i < animatedObjects.Length; i++)
        {
            animatedObjects[i].obj.localPosition = animatedObjects[i].showPosition;
            animatedObjects[i].obj.DOLocalMove(animatedObjects[i].hidePosition, animatedObjects[i].hide.duration).SetEase(animatedObjects[i].hide.ease).OnComplete(() =>
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
    public Vector3 showPosition;
    public Vector3 hidePosition;
    public AnimationInfo show;
    public AnimationInfo hide;
}

[System.Serializable]
public class AnimationInfo
{
    public float duration;
    public Ease ease;
}