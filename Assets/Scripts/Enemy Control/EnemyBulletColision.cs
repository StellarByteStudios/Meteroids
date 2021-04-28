using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletColision : MonoBehaviour
{
    public GameObject meteroidMediumTemplate;
    public GameObject meteroidSmolTemplate;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject partner = collision.gameObject;
      
        if (partner.tag.Equals("Meteroid Big"))
        {
            //Explosionssound spielen
            FindObjectOfType<AudioManager>().Play("Explosion");
            //Fragmente Spawnen
            partner.GetComponent<CreateExplosionFragments>().spawnFragments();

            Debug.Log("Spielerbullet: Kollision mit Meteroid Big");
            Vector3 spawnPoint = new Vector3(partner.transform.position.x, partner.transform.position.y, 0);
            Destroy(partner);
            GameObject meteroidMedium = Instantiate(meteroidMediumTemplate, spawnPoint, partner.transform.rotation);
            GameObject meteroidMedium2 = Instantiate(meteroidMediumTemplate, spawnPoint, partner.transform.rotation);
            Destroy(gameObject);
        }

        if (partner.tag.Equals("Meteroid Medium"))
        {
            //Explosionssound spielen
            FindObjectOfType<AudioManager>().Play("Explosion");
            //Fragmente Spawnen
            partner.GetComponent<CreateExplosionFragments>().spawnFragments();

            Debug.Log("Spielerbullet: Kollision mit Meteroid Medium");
            Vector3 spawnPoint = new Vector3(partner.transform.position.x, partner.transform.position.y, 0);
            Destroy(partner);
            GameObject meteroidSmol = Instantiate(meteroidSmolTemplate, spawnPoint, partner.transform.rotation);
            GameObject meteroidSmol2 = Instantiate(meteroidSmolTemplate, spawnPoint, partner.transform.rotation);
            Destroy(gameObject);
        }

        if (partner.tag.Equals("Meteroid Smol"))
        {
            //Explosionssound spielen
            FindObjectOfType<AudioManager>().Play("Explosion");
            //Fragmente Spawnen
            partner.GetComponent<CreateExplosionFragments>().spawnFragments();

            Debug.Log("Spielerbullet: Kollision mit Meteroid Smol");
            Destroy(partner);
            Destroy(gameObject);
        }
        Debug.Log("Irgend eine Kollision");
    }
}
