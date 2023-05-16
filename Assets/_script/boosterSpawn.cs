using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boosterSpawn : MonoBehaviour
{
    public GameObject itemPrefab; // ������� ������ ������������ ��������
    public Transform spawnPoint; // ������� ����� ������

    private float spawnTimer = 0f;
    public float spawnInterval = 1f; // ������� �������� �������� ���������

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
