using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents
{
}

public class GameEvents
{
    public static Action OnInitialized;
    public static Action OnGameStateChange;
    public static Action<AnnouncerInfo> OnAnnouncer;
    public static Action<AudioClip, float> OnSfx;
}

public class UIEvents
{
    public static Action OnPanelChanged;
}

public class InputEvents
{
    public static Action onPlayerClick;
}

public class GameplayEvents
{
    public static Action<ObstacleScore> OnObstacleScore;
    public static Action OnCarStateChange;
    public static Action OnChangeCar;
}