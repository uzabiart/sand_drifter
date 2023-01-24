using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadBump : MonoBehaviour
{
    public GameObject curr;
    public GameObject[] all;
    public Vector3 randomRotation;

    public void Init()
    {
        if (curr != null) curr.SetActive(false);

        int randomObst = UnityEngine.Random.Range(0, all.Length);
        //float randomScale = UnityEngine.Random.Range(2f, 3f);
        curr = all[randomObst];
        curr.SetActive(true);

        //transform.localScale = Vector3.one * randomScale;
        transform.localEulerAngles = new Vector3(0f, UnityEngine.Random.Range(0, 360), 0f);
    }
}