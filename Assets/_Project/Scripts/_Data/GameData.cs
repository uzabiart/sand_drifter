using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EGameState
{
    None = 0,
    Intro = 10,
    Menu = 20,
    Gameplay = 30,
}

[CreateAssetMenu(menuName = "UMI/GameData")]
public class GameData : ScriptableObject
{
    public static GameData Instance;
    public PlayerData localPlayer;
    public ArtData artData;
    public List<PlayerData> players = new List<PlayerData>();
    public EGameState CurrentGameState;
    public EGameState PreviousGameState;

    public EPanelType CurrentPanel;

    public GameplaySettingsData gameplaySettings;

    public void Init()
    {
        Instance = this;
        ChangeGameState(EGameState.Menu);
        GameEvents.OnInitialized?.Invoke();
    }

    public void ChangePanel(EPanelType panel)
    {
        CurrentPanel = panel;
        UIEvents.OnPanelChanged?.Invoke();
    }

    public void ChangeGameState(EGameState newState)
    {
        CurrentGameState = newState;
        GameEvents.OnGameStateChange?.Invoke();
        PreviousGameState = newState;
    }
}

[System.Serializable]
public class PlayerData
{
    public ECarState state;
    public float speed;
    public float gforce;
    public CarData currentCar;

    public Action OnGainedBoost;

    public void ChangeCar(CarData newCar)
    {
        currentCar = newCar;
        GameplayEvents.OnChangeCar?.Invoke();
    }
    public void UpdateSpeed(float speed)
    {
        this.speed = speed;
    }
    public void UpdateGforce(float gforce)
    {
        this.gforce = gforce;
    }
    public void ChangeState(ECarState newState)
    {
        state = newState;
        GameplayEvents.OnCarStateChange?.Invoke();
    }
}