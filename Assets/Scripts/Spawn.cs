using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform SpawnPos;
    public Transform SpawnPos2;
    public GameObject Enemy;
    public float time;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    void Repeat()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(time);

        // выбор случайной позиции спавна
        Transform spawnPosition = Random.Range(0, 2) == 0 ? SpawnPos : SpawnPos2;

        // спавн врага на выбранной позиции
        Instantiate(Enemy, spawnPosition.position, Quaternion.identity);

        Repeat();
    }
}
