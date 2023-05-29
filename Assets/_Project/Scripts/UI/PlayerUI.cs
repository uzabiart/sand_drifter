using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI speed;
    public TextMeshProUGUI gforce;
    public TextMeshProUGUI score;
    public Image vignette;

    public Image speedometerBar;
    public Image speedometerDingle;

    float savedSpeed;
    float savedGforce;

    public GameObject[] inGameplayObjects;

    private void OnEnable()
    {
        print("Cos");
        GameplayEvents.OnObstacleScore += ShowScore;
        GameEvents.OnGameStateChange += ManageState;
    }
    private void OnDisable()
    {
        GameplayEvents.OnObstacleScore -= ShowScore;
        GameEvents.OnGameStateChange -= ManageState;
    }

    private void Start()
    {
        ManageState();
    }

    private void ManageState()
    {
        if (GameData.Instance.CurrentGameState == EGameState.Menu)
        {
            foreach (GameObject obj in inGameplayObjects)
                obj.SetActive(false);
        }
        if (GameData.Instance.CurrentGameState == EGameState.Gameplay)
        {
            foreach (GameObject obj in inGameplayObjects)
                obj.SetActive(true);
        }
    }

    private void ShowScore(ObstacleScore sc)
    {
        if (sc.multiply > 1)
            score.text = $"{400 - (int)(sc.dist * 100)} + {(int)(sc.gforce * 5)} x {sc.multiply}";
    }

    private void Update()
    {
        UpdateValuesRealTime();
    }

    private void UpdateValuesRealTime()
    {
        if (savedSpeed != GameData.Instance.localPlayer.speed) UpdateSpeed();
        if (savedGforce != GameData.Instance.localPlayer.gforce) UpdateGforce();
    }

    private void UpdateGforce()
    {
        savedGforce = GameData.Instance.localPlayer.gforce;
        //gforce.text = $"{(int)(GameData.Instance.localPlayer.gforce + 0.5f) * 2}<size=50>g";
        gforce.text = $"{(int)((GameData.Instance.localPlayer.gforce * 2) + 0.5f)}<size=30>g";
        float moddedGforce = GameData.Instance.localPlayer.gforce;

        if (GameData.Instance.localPlayer.gforce < 1f)
            moddedGforce = 0;
        else
            moddedGforce -= 1f;

        if (vignette != null)
            vignette.DOFade(moddedGforce * 0.2f, 0.5f);
    }

    private void UpdateSpeed()
    {
        savedSpeed = GameData.Instance.localPlayer.speed;
        //speed.text = $"{(int)(GameData.Instance.localPlayer.speed + 0.5f)}<size=50>m/s";
        speed.text = $"{(int)(GameData.Instance.localPlayer.speed + 0.5f)}\n<size=30>m/s";

        //min = 0.37
        //max = 0.67

        float mod = (30 / GameData.Instance.gameplaySettings.defaultSpeed);
        speedometerBar.fillAmount = ((GameData.Instance.localPlayer.speed - GameData.Instance.gameplaySettings.defaultSpeed) * 0.01f) * mod + 0.37f;

        mod = (72.26f / GameData.Instance.gameplaySettings.defaultSpeed);
        speedometerDingle.transform.localEulerAngles = new Vector3(0f, 0f, 72.26f);
    }

}