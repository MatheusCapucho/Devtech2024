using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private int maxEnemies = 10;
    [SerializeField] private int firstEnemies = 2;
    private int spawnedEnemies = 0;

    [SerializeField] private float spawnCD = 3f;
    private float currentTime = 0f;

    [SerializeField] private GameObject[] enemiesPrefab;
    [SerializeField] private int[] enemiesSpawnWeight;

    private int totalWeight = 0;

    private Transform[] spawnPoints;

    private void Awake()
    {
        spawnPoints = new Transform[transform.childCount];
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
            
        }
        for(int i = 0;i < enemiesSpawnWeight.Length;i++)
        {
            totalWeight += enemiesSpawnWeight[i];
        }

    }

    private void Start()
    {
        for(int i = 0; i < firstEnemies; i++)
        {
            SpawnRandomEnemy();
            
        }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(spawnedEnemies < maxEnemies && currentTime >= spawnCD)
        {
            currentTime = 0;
            SpawnRandomEnemy();
        }

    }

    private void SpawnRandomEnemy()
    {
        var rng = Random.Range(0, totalWeight);
        var pointRng = Random.Range(0, spawnPoints.Length);
        int totalPossibilities = enemiesPrefab.Length;
        int it = totalPossibilities;

        for(int i = 0; i < totalPossibilities; i++)
        {
            if(rng <= enemiesSpawnWeight[totalPossibilities - it])
            {
                Instantiate(enemiesPrefab[i], spawnPoints[pointRng].position, Quaternion.identity);
                spawnedEnemies++;
                break;
            }
            it--;
        }
    }




}
