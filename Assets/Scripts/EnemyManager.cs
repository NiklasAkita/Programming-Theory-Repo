using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<GameObject> enemyPrefab;
    public float spawnTime = 3f;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyTimer());

    }

    void Update()
    {
        // rotate
        transform.Rotate(0, 1, 0);
    }

    IEnumerator SpawnEnemyTimer()
    {
        yield return new WaitForSeconds(Random.Range(spawnTime - 2.9f, spawnTime));
        SpawnEnemy();
        StartCoroutine(SpawnEnemyTimer());
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefab.Count);
        Instantiate(enemyPrefab[randomIndex], spawnPoint.transform.position, Quaternion.identity);
    }
}
