using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject partner = collision.gameObject;

        if (partner.tag.Equals("Bullet"))
        {
            Debug.Log("Ship trifft auf Bullet");
        }
        else
        {

            Debug.Log("Getroffen von: " + partner.name);

            //Explosionssound spielen
            FindObjectOfType<AudioManager>().Play("Explosion");
            //Fragmente Spawnen
            gameObject.GetComponent<CreateExplosionFragments>().spawnFragments();

            GameObject UI = GameObject.FindGameObjectWithTag("UI");
            GameObject lifes = UI.transform.GetChild(1).gameObject;
            Lifes lifesSkript = lifes.GetComponent<Lifes>();

            lifesSkript.decLife();
            
            if (lifesSkript.getLife() == 0)
            {
                //Nach dem Tot den Ship Thrust Sound beenden
                FindObjectOfType<AudioManager>().Stop("Ship Thrust");

                Debug.Log("Schiff == Tot");
                SceneManager.LoadScene("Enter Highscore");
            }
            else
            {
                GameObject[] meteroidBig = GameObject.FindGameObjectsWithTag("Meteroid Big");
                GameObject[] meteroidMid = GameObject.FindGameObjectsWithTag("Meteroid Medium");
                GameObject[] meteroidSmol = GameObject.FindGameObjectsWithTag("Meteroid Smol");
                GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
                GameObject[] badBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
                GameObject[] ufoBig = GameObject.FindGameObjectsWithTag("Enemy Big");
                GameObject[] ufoSmall = GameObject.FindGameObjectsWithTag("Enemy Small");

                destroyGameObjects(meteroidBig);
                destroyGameObjects(meteroidMid);
                destroyGameObjects(meteroidSmol);
                destroyGameObjects(bullets);
                destroyGameObjects(badBullets);
                destroyGameObjects(ufoBig);
                destroyGameObjects(ufoSmall);

                GameObject controller = GameObject.FindGameObjectWithTag("GameController");
                ShipControl shipSkript = controller.GetComponent<ShipControl>();
                shipSkript.resetPosAndSpeed();
            }
        }        
    }

    public void destroyGameObjects(GameObject[] objects) {
        foreach (GameObject instanz in objects)
        {
            Destroy(instanz);
        }
    }
}
