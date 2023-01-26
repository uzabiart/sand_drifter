using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    public GameObject boost;

    private void OnEnable()
    {
        if (GameData.Instance == null)
            GameEvents.OnInitialized += Sub;
        else
            Sub();
    }
    private void OnDisable()
    {
        GameEvents.OnInitialized -= Sub;
        GameData.Instance.localPlayer.OnGainedBoost -= ShowGainBoost;
    }

    public void Sub()
    {
        GameData.Instance.localPlayer.OnGainedBoost += ShowGainBoost;
    }

    public void ShowGainBoost()
    {
        boost.SetActive(false);
        boost.SetActive(true);
    }
}