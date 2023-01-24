using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEvents
{
}

public class InputEvents
{
    public static Action onPlayerClick;
}

public class GameplayEvents
{
    public static Action<ObstacleScore> OnObstacleScore;
    public static Action OnCarStateChange;
}