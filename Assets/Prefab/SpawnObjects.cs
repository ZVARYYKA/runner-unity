using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectToSpawn;  // префаб создаваемого объекта
    public Transform[] spawnPoints;   // массив точек, на которых создаются объекты

    void Start()
    {
        // создаем объект на каждой точке из массива
        foreach (Transform spawnPoint in spawnPoints)
        {
            Instantiate(objectToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
