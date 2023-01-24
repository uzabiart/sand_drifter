using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public SpriteRenderer rend;
    private void Start()
    {
        rend.sprite = GameData.Instance.artData.GetRandomSprite();
    }
}