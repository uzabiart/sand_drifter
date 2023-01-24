using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public RoadBump yellowObstacle;
    public GameObject speedBoost;
    public Transform parent;

    public List<RoadBump> obstacles = new List<RoadBump>();

    public int curr;

    private void Awake()
    {
        InitSpawn();
    }
    private void InitSpawn()
    {
        for (int i = 0; i < 10; i++)
        {
            //RoadBump newObstacle = Instantiate(yellowObstacle, parent);
            //newObstacle.gameObject.SetActive(false);
            obstacles.Add(Instantiate(yellowObstacle, parent));
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnerCoroutine());
        StartCoroutine(SpawnRoadBump());
        //StartCoroutine(SpawnRoadBump());
        StartCoroutine(SpawnSpeedBoost());
    }

    private IEnumerator SpawnerCoroutine()
    {
        if (GameData.Instance.localPlayer.state == ECarState.Dead) yield break;

        Instantiate(obstaclePrefab, parent).transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 36);
        yield return new WaitForSeconds(2.4f);
        StartCoroutine(SpawnerCoroutine());
    }

    private IEnumerator SpawnRoadBump()
    {
        if (GameData.Instance.localPlayer.state == ECarState.Dead) yield break;

        float randomTime = UnityEngine.Random.Range(0.1f, 1f);
        float randomRange = UnityEngine.Random.Range(-7f, 7f);
        RoadBump newObstacle = obstacles[curr];
        curr++;
        if (curr >= obstacles.Count) curr = 0;

        newObstacle.Init();
        newObstacle.transform.position = new Vector3(transform.position.x + randomRange, transform.position.y, transform.position.z);
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(SpawnRoadBump());
    }
    private IEnumerator SpawnSpeedBoost()
    {
        if (GameData.Instance.localPlayer.state == ECarState.Dead) yield break;

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