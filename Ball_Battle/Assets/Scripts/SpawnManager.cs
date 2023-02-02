using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9f;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
        InvokeRepeating(nameof(SpawnEnemy), 4, 2);
    }
    void SpawnEnemy()
    {
        float spawnXZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new(spawnXZ, 0, spawnXZ);
        Instantiate(enemyPrefab, spawnPosition, enemyPrefab.transform.rotation);
    }
}
