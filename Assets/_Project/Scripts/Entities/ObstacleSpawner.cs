using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GroundTile groundPrefab;
    public RoadBump yellowObstacle;
    public GameObject speedBoost;
    public Transform parent;

    public List<RoadBump> obstacles = new List<RoadBump>();
    public List<GroundTile> grounds = new List<GroundTile>();

    public int curr;
    public int curr_gr;

    private void OnEnable()
    {
        GameEvents.OnGameStateChange += ManageSpawner;
    }
    private void OnDisable()
    {
        GameEvents.OnGameStateChange -= ManageSpawner;
    }

    private void Start()
    {
        StartCoroutine(GroundSpawner());
    }

    private void ManageSpawner()
    {
        if (GameData.Instance.CurrentGameState != EGameState.Gameplay) { StopAllCoroutines(); return; }

        StartSpawn();
    }

    private void Awake()
    {
        InitSpawn();
    }
    private void InitSpawn()
    {
        for (int i = 0; i < 10; i++)
            obstacles.Add(Instantiate(yellowObstacle, parent));

        for (int i = 0; i < 5; i++)
            grounds.Add(Instantiate(groundPrefab, parent));
    }

    private void StartSpawn()
    {
        StartCoroutine(SpawnRoadBump());
        //StartCoroutine(SpawnRoadBump());
        StartCoroutine(SpawnSpeedBoost());
    }

    private IEnumerator GroundSpawner()
    {
        if (GameData.Instance.localPlayer.state == ECarState.Dead) yield break;

        GroundTile newTile = grounds[curr_gr];
        curr_gr++;
        if (curr_gr >= grounds.Count) curr_gr = 0;

        newTile.Init();
        newTile.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 36);

        yield return new WaitForSeconds(2.4f * (GameData.Instance.gameplaySettings.defaultSpeed / GameData.Instance.localPlayer.speed));
        StartCoroutine(GroundSpawner());
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