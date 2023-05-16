using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _delzone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Delzone"))
        {
            Destroy(gameObject);
        }
    }
}
