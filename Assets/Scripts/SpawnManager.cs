using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] meteors;

    private float zSpawnPos = 10.0f;
    private float xSpawnRange = 12.0f;
    private float yOffset = 0.75f;

    private float startDelay = 1.0f;
    private float enemySpawnTime = 3.0f;
    private float meteorSpawnTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnRandomMeteor", startDelay, meteorSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, yOffset, zSpawnPos);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnRandomMeteor()
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, meteors.Length);

        Vector3 spawnPos = new Vector3(randomX, yOffset, zSpawnPos);

        Instantiate(meteors[randomIndex], spawnPos, meteors[randomIndex].gameObject.transform.rotation);
    }
}
