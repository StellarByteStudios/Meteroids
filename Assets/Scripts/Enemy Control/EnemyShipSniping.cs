using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSniping : MonoBehaviour
{
    public GameObject bulletTemplate;
    public float timeTillNextShot = 0.0f;
    public float shootingRate = 0.75f;
    public float inaccuracyRate = 5;
    void Update()
    {
        GameObject ship = GameObject.FindGameObjectWithTag("Ship");
        
        if (Time.time > timeTillNextShot)
        {
            timeTillNextShot = Time.time + shootingRate;
            Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y);
            Vector3 shipPosision = ship.transform.position;
            float inaccuracy = randomBetween(inaccuracyRate);
            Vector3 aimVector = shipPosision - spawnPoint;
            float aimAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg;
            Vector3 directionVector = new Vector3(0, 0, aimAngle - 90 + inaccuracy);
            GameObject bullet = Instantiate(bulletTemplate, spawnPoint, Quaternion.Euler(directionVector));
            FindObjectOfType<AudioManager>().Play("Shoot");
            Destroy(bullet, 3f);
        }
    }

    private float randomBetween(float amp)
    {
        return UnityEngine.Random.Range(-amp, amp);
    }
}
