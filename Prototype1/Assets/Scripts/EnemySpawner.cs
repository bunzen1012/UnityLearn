using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnRangeX = Random.Range(-9, 9);
        float spawnRangeZ = Random.Range(-9, 9);

        Vector3 randomPosition = new Vector3(spawnRangeX, 0,spawnRangeZ);

        return randomPosition;
    }
}
