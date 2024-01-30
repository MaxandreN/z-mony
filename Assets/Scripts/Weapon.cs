using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Transform container;
    [Range(5f, 30f)] public float bulletSpeed = 15f;
    [Range(0, 30)] private int magazine = 30;
    private IEnumerator _enumerator;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && magazine > 0)
        {
            magazine --;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation, container);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed; 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
    
    private void Reload () {
        magazine = 30;
    }
}
