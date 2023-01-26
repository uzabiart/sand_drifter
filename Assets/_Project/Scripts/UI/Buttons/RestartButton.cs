using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        GameData.Instance.ChangeGameState(EGameState.Menu);
        SceneManager.LoadScene(0);
    }
}