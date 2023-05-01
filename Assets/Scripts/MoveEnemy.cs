using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public float speed;
    public Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(dir * speed, Space.World);
        if (gameObject.transform.position.x < -15)
        {
            Destroy(gameObject);
        }

    }
}
