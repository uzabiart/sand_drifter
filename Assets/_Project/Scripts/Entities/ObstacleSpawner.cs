using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject yellowObstacle;
    public GameObject speedBoost;
    public Transform parent;

    private void Start()
    {
        //StartCoroutine(SpawnerCoroutine());
        StartCoroutine(SpawnRoadBump());
        StartCoroutine(SpawnSpeedBoost());
    }

    private IEnumerator SpawnerCoroutine()
    {
        Instantiate(obstaclePrefab, parent).transform.position = transform.position;
        yield return new WaitForSeconds(1f);
        StartCoroutine(SpawnerCoroutine());
    }

    private IEnumerator SpawnRoadBump()
    {
        float randomScale = UnityEngine.Random.Range(1f, 3f);
        float randomTime = UnityEngine.Random.Range(0.2f, 1f);
        float randomRange = UnityEngine.Random.Range(-4.4f, 4.4f);
        Transform newObstacle = Instantiate(yellowObstacle, parent).transform;
        newObstacle.position = new Vector3(transform.position.x + randomRange, transform.position.y, transform.position.z);
        newObstacle.localScale = Vector3.one * randomScale;
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(SpawnRoadBump());
    }
    private IEnumerator SpawnSpeedBoost()
    {
        //float randomScale = UnityEngine.Random.Range(1f, 3f);
        float randomTime = UnityEngine.Random.Range(2f, 4f);
        float randomRange = UnityEngine.Random.Range(-4.4f, 4.4f);
        Transform newObstacle = Instantiate(speedBoost, parent).transform;
        newObstacle.position = new Vector3(transform.position.x + randomRange, transform.position.y, transform.position.z);
        //newObstacle.localScale = Vector3.one * randomScale;
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(SpawnSpeedBoost());
    }
}