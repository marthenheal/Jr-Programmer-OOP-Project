using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] rocks;

    private GameUIHandler gameUI;

    private float zSpawnPos = 10.0f;
    private float xSpawnRange = 12.0f;
    private float yOffset = 0.75f;

    private float startDelay = 1.0f;
    private float enemySpawnTime = 3.0f;
    private float rockSpawnTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameUI = GameObject.Find("GameUIHandler").GetComponent<GameUIHandler>();
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnRandomRock", startDelay, rockSpawnTime);
    }

    void SpawnRandomEnemy() //ABSTRACTION
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, yOffset, zSpawnPos);

        if (gameUI.isGameActive)
        {
            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnRandomRock() //ABSTRACTION
    {
        float randomX = Random.Range(-xSpawnRange, xSpawnRange);
        int randomIndex = Random.Range(0, rocks.Length);

        Vector3 spawnPos = new Vector3(randomX, yOffset, zSpawnPos);

        if (gameUI.isGameActive)
        {
            Instantiate(rocks[randomIndex], spawnPos, rocks[randomIndex].gameObject.transform.rotation);
        }          
    }
}
