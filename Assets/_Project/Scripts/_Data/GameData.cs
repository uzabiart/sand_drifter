using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UMI/GameData")]
public class GameData : ScriptableObject
{
    public static GameData Instance;
    public PlayerData localPlayer;
    public ArtData artData;
    public List<PlayerData> players = new List<PlayerData>();

    public GameplaySettingsData gameplaySettings;

    public void Init()
    {
        Instance = this;
    }
}

[System.Serializable]
public class PlayerData
{
    public ECarState state;
    public float speed;
    public float gforce;

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