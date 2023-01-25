using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GameObject curr;
    public GameObject[] all;

    public void Init()
    {
        if (curr != null) curr.SetActive(false);

        int randomObst = UnityEngine.Random.Range(0, all.Length);
        curr = all[randomObst];
        curr.SetActive(true);
    }
}