using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShipCollision : MonoBehaviour
{
    public GameObject meteroidMediumTemplate;
    public GameObject meteroidSmolTemplate;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject partner = collision.gameObject;

        if (partner.tag.Equals("Bullet"))
        {
            Debug.Log("Enemy trifft auf Spieler Bullet");
        }
        
        if(partner.tag.Equals("EnemyBullet"))
        {
            Debug.Log("Enemy trifft auf Eigene Bullet");
        }

        if (partner.tag.Equals("Meteroid Big"))
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            Debug.Log("Spielerbullet: Kollision mit Meteroid Big");
            Vector3 spawnPoint = new Vector3(partner.transform.position.x, partner.transform.position.y, 0);
            Destroy(partner);
            GameObject meteroidMedium = Instantiate(meteroidMediumTemplate, spawnPoint, partner.transform.rotation);
            GameObject meteroidMedium2 = Instantiate(meteroidMediumTemplate, spawnPoint, partner.transform.rotation);
            Destroy(gameObject);
        }

        if (partner.tag.Equals("Meteroid Medium"))
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            Debug.Log("Spielerbullet: Kollision mit Meteroid Medium");
            Vector3 spawnPoint = new Vector3(partner.transform.position.x, partner.transform.position.y, 0);
            Destroy(partner);
            GameObject meteroidSmol = Instantiate(meteroidSmolTemplate, spawnPoint, partner.transform.rotation);
            GameObject meteroidSmol2 = Instantiate(meteroidSmolTemplate, spawnPoint, partner.transform.rotation);
            Destroy(gameObject);
        }

        if (partner.tag.Equals("Meteroid Smol"))
        {
            FindObjectOfType<AudioManager>().Play("Explosion");
            Debug.Log("Spielerbullet: Kollision mit Meteroid Smol");
            Destroy(partner);
            Destroy(gameObject);
        }
    }
}
