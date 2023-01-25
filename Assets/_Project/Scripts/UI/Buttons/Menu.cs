using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Menu : MonoBehaviour
{
    public CanvasGroup restartButton;

    private void OnEnable()
    {
        GameplayEvents.OnCarStateChange += ManageState;
    }
    private void OnDisable()
    {
        GameplayEvents.OnCarStateChange -= ManageState;
    }

    public void ManageState()
    {
        if (GameData.Instance.localPlayer.state == ECarState.Dead)
            StartCoroutine(FadeInRestartButton());
    }

    private IEnumerator FadeInRestartButton()
    {
        yield return new WaitForSeconds(2.5f);
        restartButton.DOFade(1f, 2f);
        yield return new WaitForSeconds(1f);
        restartButton.interactable = true;
        restartButton.blocksRaycasts = true;
    }
}
