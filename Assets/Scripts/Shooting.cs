using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletTemplate;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject[] menu = GameObject.FindGameObjectsWithTag("Menu");
            if (menu.Length > 0)
            {
                return;
            }

            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            if (bullets.Length < 4)
            {
                FindObjectOfType<AudioManager>().Play("Shoot");
                Vector3 spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                GameObject bullet = Instantiate(bulletTemplate, spawnPoint, transform.rotation);
                Destroy(bullet, 1.2f);
            }
        }
    }
}
