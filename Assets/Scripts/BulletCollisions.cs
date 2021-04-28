using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisions : MonoBehaviour
{
    public GameObject meteroidMediumTemplate;
    public GameObject meteroidSmolTemplate;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject partner = collision.gameObject;
        
        GameObject UI = GameObject.FindGameObjectWithTag("UI");
        GameObject score = UI.transform.GetChild(0).gameObject;
        ScoreInGame scoreSkript = score.GetComponent<ScoreInGame>();
        
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
            scoreSkript.addScore(20);
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
            scoreSkript.addScore(50);
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
            scoreSkript.addScore(100);
            Destroy(gameObject);
        }

        if (partner.tag.Equals("Enemy Big"))
        {
            //Explosionssound spielen
            FindObjectOfType<AudioManager>().Play("Explosion");
            //Fragmente Spawnen
            partner.GetComponent<CreateExplosionFragments>().spawnFragments();

            Debug.Log("Spielerbullet: Kollision mit Enemy Big");
            Destroy(partner);
            scoreSkript.addScore(200);
            Destroy(gameObject);
        }

        if (partner.tag.Equals("Enemy Small"))
        {
            //Explosionssound spielen
            FindObjectOfType<AudioManager>().Play("Explosion");
            //Fragmente Spawnen
            partner.GetComponent<CreateExplosionFragments>().spawnFragments();

            Debug.Log("Spielerbullet: Kollision mit Enemy Small");
            Destroy(partner);
            scoreSkript.addScore(1000);
            Destroy(gameObject);
        }


        Debug.Log("Irgend eine Kollision von Spielerbullet");
    }
}
