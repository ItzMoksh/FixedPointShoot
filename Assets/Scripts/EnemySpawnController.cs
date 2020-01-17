using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private Transform rightLimit = null;
    [SerializeField] private Transform leftLimit = null;
    [SerializeField] private Transform height = null;

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (true)
        {
            float randomX = Random.Range(leftLimit.position.x, rightLimit.position.x);
            Instantiate(enemyPrefab, new Vector3(randomX, height.position.y, 0), Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
