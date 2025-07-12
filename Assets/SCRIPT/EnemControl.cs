using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemControl : MonoBehaviour
{
    public GameObject enemPrefab;
    public float minInstantiateValue;
    public float maxInstantiateValue;
    public float destroyTime = 10f;

    private void Start()
    {
        InvokeRepeating("InitiateEnemies", 0f, 2f);
    }

    void InitiateEnemies()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(minInstantiateValue, maxInstantiateValue), 6f);
        GameObject enemy = Instantiate(enemPrefab, spawnPosition, Quaternion.identity);
    }
}
