using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public GameData gameData;
    private void Awake()
    {
        gameData.Init();
        Application.targetFrameRate = 120;
    }
}