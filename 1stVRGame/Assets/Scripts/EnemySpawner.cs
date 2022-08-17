﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public GameObject enemyPrefab, enemies;

    public float enemyBurstCount = 3, spawnTime=3;

    float updateTime;

    Transform location;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
            spawnPoints.Add(child);
    }

    // Update is called once per frame
    void Update()
    {
        //SpawnEnemy();
        if (Time.time > updateTime)
        {
            updateTime = Time.time + spawnTime;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        if (enemies.transform.childCount < enemyBurstCount)
        {
            location = spawnPoints[Random.Range(0, transform.childCount)];
            var enemyInstance = Instantiate(enemyPrefab, location);
            enemyInstance.transform.SetParent(enemies.transform);
            enemyInstance.transform.LookAt(Vector3.zero);
        }
    }
}
