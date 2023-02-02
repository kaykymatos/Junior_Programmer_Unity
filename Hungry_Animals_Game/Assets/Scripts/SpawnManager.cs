using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnRandomAnimal), 2, 1.5f);
    }
    void SpawnRandomAnimal()
    {
        Vector3 spawnPos = new(Random.Range(-10, 10), 0, 20);
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
