using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public enum ECarState
{
    None = 0,
    Driving = 10,
    Dead = 20,
}

public class Car : MonoBehaviour
{
    public float defaultSpeed;
    public float currentSpeed;
    public GameObject ded;
    public GameObject view;
    public GameObject ui;

    private void Awake()
    {
        currentSpeed = defaultSpeed;
    }

    public GameObject debugPrefab;
    public Transform parent;
    GameObject newVfx;

    private void Start()
    {
        GameData.Instance.localPlayer.state = ECarState.Driving;
        //StartCoroutine(SpawnerCoroutine());
    }

    private IEnumerator SpawnerCoroutine()
    {
        newVfx = Instantiate(debugPrefab, parent);
        newVfx.transform.position = transform.position;
        newVfx.transform.DOLocalMoveZ(-10, 1f).SetEase(Ease.InCubic);
        yield return new WaitForSeconds(5f);
        Destroy(newVfx);
        StartCoroutine(SpawnerCoroutine());
    }

    public void Dead()
    {
        view.SetActive(false);
        ui.SetActive(false);
        ded.SetActive(true);
        transform.DOMoveZ(transform.position.z + 20f, 1f).SetEase(Ease.OutCubic);
        GameData.Instance.localPlayer.ChangeState(ECarState.Dead);
    }

    private void Update()
    {
        if (GameData.Instance.localPlayer.state == ECarState.Dead) return;
        transform.Translate(Vector3.forward * Time.deltaTime * currentSpeed);
        GameData.Instance.localPlayer.UpdateSpeed(currentSpeed * 2);
    }
}