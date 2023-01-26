using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : MonoBehaviour
{
    public GameData gameData;
    public static ProjectContext Instance;

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }

        //else if (SceneManager.GetActiveScene().buildIndex != 0)
        //{
        //    SceneManager.LoadScene(0);
        //    return;
        //}

        Instance = this;
        DontDestroyOnLoad(this);
        gameData.Init();
        Application.targetFrameRate = 120;
    }
}