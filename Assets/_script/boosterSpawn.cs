using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosterSpawn : MonoBehaviour
{
    public GameObject itemPrefab; // Задайте префаб создаваемого предмета
    public Transform spawnPoint; // Задайте точку спавна

    private float spawnTimer = 0f;
    public float spawnInterval = 1f; // Задайте интервал создания предметов

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}
