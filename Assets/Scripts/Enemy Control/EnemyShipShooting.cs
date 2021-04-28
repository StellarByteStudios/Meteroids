using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipShooting : MonoBehaviour
{

    public GameObject bulletTemplate;
    public float timeTillNextShot = 0.0f;
    public float shootingRate = 1f;
    void Update()
    {
        
        if (Time.time > timeTillNextShot)
        {
            timeTillNextShot = Time.time + shootingRate;
            Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Quaternion direction = Quaternion.Euler(0, 0, randomTo(360f));
            GameObject bullet = Instantiate(bulletTemplate, spawnPoint, direction);
            FindObjectOfType<AudioManager>().Play("Shoot");
            Destroy(bullet, 3f);
        }
    }

    private float randomTo(float max)
    {
        return UnityEngine.Random.Range(0f, max);
    }
}
