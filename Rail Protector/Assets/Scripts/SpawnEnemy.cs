using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemySpawnType;
    public Transform spawnPoint;
    public int enemySpawnCount;
    public float ogSpawnTime;
    public float spawnTime;
    public float finalSpawnTime;

    public float timeSpeed;
    //public bool spawning = false;
    // Spawn Enemy
    public void Update()
    {
        spawnTime -= timeSpeed * Time.deltaTime;

        if (gameObject.tag == "Spawn")
        {
            EnemySpawn();

        } else
        {
            SpawnStation();
        }
    }
    // Spawn Station
    public void SpawnStation()
    {
        if(GameObject.FindGameObjectWithTag("Spawn") == null 
            && GameObject.FindGameObjectWithTag("Enemy A") == null
            && GameObject.FindGameObjectWithTag("Enemy B") == null
            && GameObject.FindGameObjectWithTag("Boss") == null)
        {
            if (enemySpawnCount > 0 && spawnTime <= 0)
            {
                enemySpawnCount -= 1;
                Instantiate(enemySpawnType, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }

    public void EnemySpawn()
    {
        if (enemySpawnCount > 1 && spawnTime <= 0)
        {
            spawnTime = ogSpawnTime;
            enemySpawnCount -= 1;
            Instantiate(enemySpawnType, spawnPoint.position, spawnPoint.rotation);
        } else if (enemySpawnCount == 1 && spawnTime <= 0)
        {
            spawnTime = finalSpawnTime;
            enemySpawnCount -= 1;
            Instantiate(enemySpawnType, spawnPoint.position, spawnPoint.rotation);
        }
        else
            if (enemySpawnCount <= 0 && GameObject.Find(enemySpawnType.tag) == null)
        {
            Destroy(gameObject);
        }
    }
}
