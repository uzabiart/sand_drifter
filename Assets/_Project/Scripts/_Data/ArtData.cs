using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UMI/ArtData")]
public class ArtData : ScriptableObject
{
    public Sprite[] possibleGroundTextures;
    public GameData[] possibleObstacles;

    public Sprite GetRandomSprite()
    {
        return possibleGroundTextures[UnityEngine.Random.Range(0, possibleGroundTextures.Length)];
    }
}