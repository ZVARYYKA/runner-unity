using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject Enemy;
    public float time;
    // Start is called before the first frame update
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
        Instantiate(Enemy, SpawnPos.position, Quaternion.identity);
        Repeat();
    }
}
