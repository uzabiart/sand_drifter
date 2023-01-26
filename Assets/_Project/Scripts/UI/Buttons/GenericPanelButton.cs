using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPanelType
{
    None = 0,
    Menu = 5,
    Gameplay = 10,
    Skins = 20,
}

public class GenericPanelButton : MonoBehaviour
{
    public EPanelType panelType;

    public void OnClick()
    {
        GameData.Instance.ChangePanel(panelType);
    }
}