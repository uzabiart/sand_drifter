using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceAtStart : MonoBehaviour
{
    public Rigidbody rigi;
    public float force = 500;

    private void Start()
    {
        rigi.AddForce(Vector3.forward * UnityEngine.Random.Range(5000f, 15000f)/*UnityEngine.Random.Range(250f, 500f)*/);
    }

    [Button]
    public void Force()
    {
        rigi.AddForce(Vector3.forward * force/*UnityEngine.Random.Range(250f, 500f)*/);
    }
}