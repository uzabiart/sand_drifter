using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    Vector3 newPos;
    public float followSpeed = 1f;

    public bool x;
    public bool y;
    public bool z;

    private void FixedUpdate()
    {
        if (followSpeed != 0)
        {
            newPos = new Vector3(
                x ? target.position.x : transform.position.x,
                y ? target.position.y : transform.position.y,
                z ? target.position.z : transform.position.z
                );

            transform.DOMove(newPos + offset, followSpeed);
        }
        else
        {
            transform.position = target.position + offset;
        }
    }

    public void Attach()
    {
        transform.parent = target;
    }
    public void Detach()
    {
        transform.parent = null;
    }
}