using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject[] enemyPrefabs;
    public Transform[] spawnPoints;
    public float initialSpawnDelay = 2f;
    public float spawnInterval = 3f;
    public int maxEnemies = 10;
    
    [Header("Wave Settings")]
    public int enemiesPerWave = 5;
    public float waveDelay = 5f;
    
    private List<GameObject> activeEnemies = new List<GameObject>();
    private int currentWave = 1;
    private bool isSpawning = false;

    void Start()
    {
        StartSpawning();
    }

    void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            InvokeRepeating("SpawnEnemy", initialSpawnDelay, spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        if (activeEnemies.Count >= maxEnemies)
            return;
        
        if (activeEnemies.Count >= enemiesPerWave * currentWave)
            return;
        
        if (enemyPrefabs.Length == 0 || spawnPoints.Length == 0)
            return;
        
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        activeEnemies.Add(enemy);
        
        EnemyAI enemyAI = enemy.GetComponent<EnemyAI>();
        if (enemyAI != null)
        {
            // ওয়েভ অনুযায়ী এনিমি শক্তিশালী করুন
            enemyAI.health += (currentWave - 1) * 10;
            enemyAI.damage += (currentWave - 1) * 2;
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        activeEnemies.Remove(enemy);
        
        // চেক করুন সব এনিমি মেরে ফেলেছে কিনা
        if (activeEnemies.Count == 0 && activeEnemies.Count >= enemiesPerWave * currentWave)
        {
            NextWave();
        }
    }

    void NextWave()
    {
        currentWave++;
        CancelInvoke("SpawnEnemy");
        Invoke("StartSpawning", waveDelay);
        Debug.Log($"Wave {currentWave} started!");
    }
}
