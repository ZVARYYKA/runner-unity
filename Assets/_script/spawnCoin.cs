using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnCoin : MonoBehaviour
{
    public GameObject spawnCoinPrefab;
    void Awake()
    {
        Instantiate(spawnCoinPrefab);
    }
}
