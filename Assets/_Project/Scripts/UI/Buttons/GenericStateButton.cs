using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericStateButton : MonoBehaviour
{
    public EGameState newState;

    public void OnClick()
    {
        GameData.Instance.ChangeGameState(newState);
    }
}