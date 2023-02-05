using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9f;
    public int waveNumber = 1;
    public int enemyCount = 0;
    public GameObject powerupPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);

    }
    private void Update()
    {

        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);

        }
    }
    private Vector3 GenerateRamdomPosition()
    {
        float spawnXZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new(spawnXZ, 0, spawnXZ);
        return spawnPosition;
    }
    void SpawnEnemyWave(int numberOfEnemies)
    {
        float spawnXZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new(spawnXZ, 0, spawnXZ);
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
            Instantiate(powerupPrefab, GenerateRamdomPosition(), powerupPrefab.transform.rotation);
        }

    }
}
