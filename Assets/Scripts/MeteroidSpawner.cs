using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteroidSpawner : MonoBehaviour
{
    public GameObject meteroidTemplate;
    public GameObject enemyBigTemplate;
    public GameObject enemySmallTemplate;

    public float time;
    public float spawnNextEnemy;
    public float spawnNextEnemyDelta = 25f;

    public float waitingTimeForRespawn = 1f;
    public bool restarting = false;

    private float startPoint;

    void Start()
    {
        spawnNextEnemy = Time.time + spawnNextEnemyDelta;
;

        for (int i = 0; i < 5; i++){
            float spawnX = 0;
            float spawnY = 0;

            while (!(spawnY > 6 || spawnY < -6))
            {
                spawnY = UnityEngine.Random.Range(-15.0f, 15.0f);
            }

            while (!(spawnX > 4 || spawnX < -4))
            {
                spawnX = UnityEngine.Random.Range(-10.0f, 10.0f);
            }
            Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0);
            Quaternion rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
            GameObject meteroid = Instantiate(meteroidTemplate, spawnPoint, rotation);
        }
    }

    void Update()
    {
        time = Time.time;

        //Holen des Scoreskrips   -- -- -- -- Finden der UI-- -- -- --  :: Das Child der UI(Scoretext) :: -- Skript bekommen -- --
        ScoreInGame scoreSkript = GameObject.FindGameObjectWithTag("UI").transform.GetChild(0).gameObject.GetComponent<ScoreInGame>();
        //In mehr Schritten
        /*GameObject UI = GameObject.FindGameObjectWithTag("UI");
        GameObject score = UI.transform.GetChild(0).gameObject;
        ScoreInGame scoreSkript = score.GetComponent<ScoreInGame>();*/

        //Überprüfen: ist noch was an Gegnern/Asteorieden da
        GameObject[] meteroidBig = GameObject.FindGameObjectsWithTag("Meteroid Big");
        GameObject[] meteroidMid = GameObject.FindGameObjectsWithTag("Meteroid Medium");
        GameObject[] meteroidSmol = GameObject.FindGameObjectsWithTag("Meteroid Smol");
        GameObject[] enemyBig = GameObject.FindGameObjectsWithTag("Enemy Big");
        GameObject[] enemySmall = GameObject.FindGameObjectsWithTag("Enemy Small");

        int objects = meteroidBig.Length + meteroidMid.Length + meteroidSmol.Length + enemyBig.Length + enemySmall.Length;
        int ufosCount = enemyBig.Length + enemySmall.Length;

        int meteroidsAmount;    //Zu Spawnende Meteroiden
        //Wie viele Meteroiden werden gespawned?
        if (scoreSkript.getScore() < 36000) { meteroidsAmount = 5 + Math.DivRem(scoreSkript.getScore(), 3000, out int remainder); }
        else { meteroidsAmount = 17; }

        if (objects == 0)
        {
            if (!restarting)
            {
                startPoint = Time.time;
            }
            restarting = true;

            //Spawnzeiten der Ufos zurücksetzen
            spawnNextEnemyDelta = 20f;
            spawnNextEnemy = Time.time + spawnNextEnemyDelta;


            Debug.Log("Meteriods empty");
            Debug.Log("MeteroidsAmount = " + meteroidsAmount);

            //Kurze Respawnpause

            if (restarting)
            {
                if (Time.time > startPoint + waitingTimeForRespawn)
                {
                    restarting = false;
                }
                else
                {
                    Debug.Log("In Restarting Schleife");
                    return;
                }
            }

            //Restlichen Bullets Löschen
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject b in bullets)
            {
                Destroy(b);
            }

            //x-viele (meteroidsAmount) Meteroiden werden gespawned
            for (int i = 0; i < meteroidsAmount; i++)
            {
                float spawnX = 0;
                float spawnY = 0;

                while (!(spawnY > 6 || spawnY < -6))
                {
                    spawnY = UnityEngine.Random.Range(-15.0f, 15.0f);
                }

                while (!(spawnX > 4 || spawnX < -4))
                {
                    spawnX = UnityEngine.Random.Range(-10.0f, 10.0f);
                }
                Vector3 spawnPoint = new Vector3(spawnX, spawnY, 0);
                Quaternion rotation = Quaternion.Euler(0, 0, UnityEngine.Random.Range(0, 360));
                GameObject meteroid = Instantiate(meteroidTemplate, spawnPoint, rotation);
            }
        }

        //UFOs spawnen
        if (Time.time > spawnNextEnemy)
        {
            if (ufosCount == 0)
            {
                int enemyType;
                switch (scoreSkript.getScore())
                {

                    case int score when (score <= 5000):
                        spawnUFO(enemyBigTemplate);
                        spawnNextEnemy = Time.time + spawnNextEnemyDelta - 3f;
                        break;

                    case int score when (score > 5000 && score <= 7000):
                        enemyType = UnityEngine.Random.Range(1, 100);
                        
                        if (enemyType < 90) { spawnUFO(enemyBigTemplate);   }
                        else                { spawnUFO(enemySmallTemplate); }
                        spawnNextEnemy = Time.time + spawnNextEnemyDelta - 5f;
                        break;

                    case int score when (score > 7000 && score <= 15000):
                        enemyType = UnityEngine.Random.Range(1, 100);

                        if (enemyType < 70) { spawnUFO(enemyBigTemplate);   }
                        else                { spawnUFO(enemySmallTemplate); }
                        spawnNextEnemy = Time.time + spawnNextEnemyDelta - 7f;
                        break;
                    case int score when (score > 15000 && score <= 30000):
                        enemyType = UnityEngine.Random.Range(1, 100);

                        if (enemyType < 50) { spawnUFO(enemyBigTemplate);   }
                        else                { spawnUFO(enemySmallTemplate); }
                        spawnNextEnemy = Time.time + spawnNextEnemyDelta - 10f;
                        break;
                    case int score when (score > 30000 && score <= 60000):
                        enemyType = UnityEngine.Random.Range(1, 100);

                        if (enemyType < 33) { spawnUFO(enemyBigTemplate);   }
                        else                { spawnUFO(enemySmallTemplate); }
                        spawnNextEnemy = Time.time + spawnNextEnemyDelta - 13f;
                        break;
                    case int score when (score > 60000):
                        spawnUFO(enemySmallTemplate);
                        spawnNextEnemy = Time.time + spawnNextEnemyDelta - 13f;
                        break;
                }
            }
            else
            {
                spawnNextEnemy = Time.time + 10f;
            }

            /* Altes Ufospawnen
            if (Time.time > spawnTimeNextBigEnemy)
            {
                if (ufosCount == 0) 
                {
                    switch (scoreSkript.getScore())
                    {
                        case int score when (score <= 5000):
                            spawnUFO(enemyBigTemplate);
                            spawnTimeNextBigEnemy = Time.time + spawnTimeDeltaBigEnemy - 5f;
                            break;
                        case int score when (score > 5000 && score <= 10000):
                            spawnUFO(enemyBigTemplate);
                            spawnTimeNextBigEnemy = Time.time + spawnTimeDeltaBigEnemy - 7f;
                            break;
                        case int score when (score > 10000 && score <= 30000):
                            spawnUFO(enemyBigTemplate);
                            spawnTimeNextBigEnemy = Time.time + spawnTimeDeltaBigEnemy - 10f;
                            break;
                        case int score when (score > 30000 && score <= 50000):
                            spawnUFO(enemyBigTemplate);
                            spawnTimeNextBigEnemy = Time.time + spawnTimeDeltaBigEnemy - 13f;
                            break;
                        case int score when (score > 50000):
                            spawnTimeNextBigEnemy = Time.time + spawnTimeDeltaBigEnemy;
                            break;
                    }
                }
                else
                {
                    spawnTimeNextBigEnemy = Time.time + 10f;
                }
            }

            //Kleines UFO spawnen
            if (Time.time > spawnTimeNextSmallEnemy)
            {
                if (ufosCount == 0)
                {
                    switch (scoreSkript.getScore())
                    {
                        case int score when (score <= 5000):
                            //spawnUFO(enemySmallTemplate);
                            spawnTimeNextSmallEnemy = Time.time + spawnTimeNextSmallEnemy;
                            break;
                        case int score when (score > 5000 && score <= 10000):
                            spawnUFO(enemySmallTemplate);
                            spawnTimeNextSmallEnemy = Time.time + spawnTimeNextSmallEnemy - 5f;
                            break;
                        case int score when (score > 10000 && score <= 30000):
                            spawnUFO(enemySmallTemplate);
                            spawnTimeNextSmallEnemy = Time.time + spawnTimeNextSmallEnemy - 7f;
                            break;
                        case int score when (score > 30000 && score <= 50000):
                            spawnUFO(enemySmallTemplate);
                            spawnTimeNextSmallEnemy = Time.time + spawnTimeNextSmallEnemy - 10f;
                            break;
                        case int score when (score > 50000):
                            spawnUFO(enemySmallTemplate);
                            spawnTimeNextSmallEnemy = Time.time + spawnTimeNextSmallEnemy - 13f;
                            break;
                    }
                }
                else
                {
                    spawnTimeNextSmallEnemy = Time.time + 10f;
                }*/
        }
    }
    private void spawnUFO(GameObject ufoClass)
    {
        int side = UnityEngine.Random.Range(1, 5);
        Quaternion spawnRot = new Quaternion(0, 0, 0, 0);
        Vector3 spawnPos;
        switch (side)
        {
            case 1: //Oben
                spawnPos = new Vector3(UnityEngine.Random.Range(-16f, 16f), -15, 0);
                GameObject.Instantiate(ufoClass, spawnPos, spawnRot);
                break;
            case 2: //Rechts
                spawnPos = new Vector3(-20, UnityEngine.Random.Range(-9f, 9f), 0);
                GameObject.Instantiate(ufoClass, spawnPos, spawnRot);
                break;
            case 3: //Unten
                spawnPos = new Vector3(UnityEngine.Random.Range(-16f, 16f), 15, 0);
                GameObject.Instantiate(ufoClass, spawnPos, spawnRot);
                break;
            case 4: //Links
                spawnPos = new Vector3(20, UnityEngine.Random.Range(-9f, 9f), 0);
                GameObject.Instantiate(ufoClass, spawnPos, spawnRot);
                break;
        }
    }
}
