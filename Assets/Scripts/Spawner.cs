using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject CactusPrefab;
    [SerializeField] private GameObject MushroomPrefab;
    private float spawnRadius = 20f;
    private float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 0f, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        for (int i = 0; i < Random.Range(2, 5); i++) // 2에서 4마리 사이의 랜덤한 수로 반복
        {
            Vector3 randomSpawnPoint = GetRandomPointOnCircle();
            GameObject selectedEnemyPrefab = GetRandomEnemyPrefab();
            Instantiate(selectedEnemyPrefab, randomSpawnPoint, Quaternion.identity);
        }
    }

    Vector3 GetRandomPointOnCircle()
    {
        float angle = Random.Range(0f, 360f);
        Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * spawnRadius;
        return transform.position + offset;
    }

    GameObject GetRandomEnemyPrefab()
    {
        return Random.Range(0f, 1f) > 0.5f ? CactusPrefab : MushroomPrefab;
    }
}
