using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPositionAtStart : MonoBehaviour
{
    Vector3 savedPos = Vector3.zero;
    void Start()
    {
        savedPos = transform.position;
    }

    void Update()
    {
        if (savedPos != Vector3.zero)
            transform.position = savedPos;
    }
}
