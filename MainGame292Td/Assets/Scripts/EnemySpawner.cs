using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves;
    [SerializeField] private float difficultyScaling = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeft;
    private bool isSpawning = false;

    private void Awake()
    {
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        // Your Update logic
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }

    private IEnumerator SpawnWaves()
    {
        while (true)  // Infinite loop for continuous wave spawning
        {
            yield return new WaitForSeconds(timeBetweenWaves);

            enemiesLeft = enemiesPerWave();
            isSpawning = true;

            while (enemiesLeft > 0)
            {
                SpawnEnemy();
                enemiesLeft--;
                enemiesAlive++;
                yield return new WaitForSeconds(1f / enemiesPerSecond);
            }

            while (enemiesAlive > 0)
            {
                yield return null; // Wait until all enemies are destroyed
            }

            isSpawning = false;
            currentWave++;
        }
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        GameObject enemy = Instantiate(prefabToSpawn, LevelManager.main.StartPoint.position, Quaternion.identity);

        Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
        if (enemyRigidbody != null)
        {
            enemyRigidbody.velocity = Vector2.zero;
        }
    }

    private int enemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, 0.75f));
    }
}
