using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebug : MonoBehaviour
{
    public CarData debugSkin;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            ChangeSkin();
        }
    }

    private void ChangeSkin()
    {
        GameData.Instance.localPlayer.ChangeCar(debugSkin);
    }
}
