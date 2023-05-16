using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectToSpawn;  // ������ ������������ �������
    public Transform[] spawnPoints;   // ������ �����, �� ������� ��������� �������

    void Start()
    {
        // ������� ������ �� ������ ����� �� �������
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
