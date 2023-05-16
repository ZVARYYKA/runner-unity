using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBooster : MonoBehaviour
{
    private GameObject test;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            test = collision.gameObject;
        }
    }

}
