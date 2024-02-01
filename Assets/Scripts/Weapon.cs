
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Transform container;
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip voidSound;
    public AudioClip reloadSound;

    [Range(5f, 30f)] public float bulletSpeed = 15f;
    [Range(0, 30)] private int magazine = 30;
    
    

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (magazine > 0)
            {
                magazine --;
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation, container);
                bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletSpeed; 
                audioSource.clip = shootSound;
            }
            else
            {
                audioSource.clip = voidSound;
            }
            audioSource.Play();


        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.clip = reloadSound;
            audioSource.Play();
            Reload();
        }
        
    }
    
    private void Reload () {
        magazine = 30;
    }
}
