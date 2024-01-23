using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    [Range(0f, 10f)] public float speed = 2f;
    private bool direction = true;
    
    private void Awake()
    {
    }
    
    public void Update()
    {
        if (transform.position.y < 4)
        {
            direction = true;
        }
        if (transform.position.y > 15)
        {
            direction = false;
        }

        if (direction)
        {
            transform.Translate(0,(Time.deltaTime * speed), 0);
        }
        else
        {
            transform.Translate(0,-(Time.deltaTime * speed), 0);
        }
        
        
    }
}
