using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlight : MonoBehaviour
{
    public float speed = 0.05f;
    public Vector3 speedVector = new Vector3(0, 0, 0);
    public Vector3 pos = new Vector3(10, 10, 0);
    public Quaternion rot = new Quaternion(0, 0, 0, 0);
    public float speedX, speedY;


    public float NextDirection = 0.0f;
    public float changeRate = 2.0f;
    public Quaternion angle = Quaternion.Euler(0, 0, 0);

    private void OnDestroy()
    {
        //FindObjectOfType<AudioManager>().Stop("UFO Flight");
    }
    private void Start()
    {
        //FindObjectOfType<AudioManager>().Play("UFO Flight");
        pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void Update()
    {
        //Anhalten bei Spielpause
        if (Time.deltaTime == 0)
        {
            return;
        }

        //Wechsel der Richtung
        if (Time.time > NextDirection)
        {
            NextDirection = Time.time + changeRate;
            angle = Quaternion.Euler(0, 0, randomTo(360f));
            speedX = -Mathf.Sin(angle.eulerAngles.z * Mathf.Deg2Rad) * speed * Time.deltaTime * 60;
            speedY = Mathf.Cos(angle.eulerAngles.z * Mathf.Deg2Rad) * speed * Time.deltaTime * 60;
        }

        //Setzen und Berechnen der neuen Position
        speedVector = new Vector3(speedX, speedY, 0);
        transform.SetPositionAndRotation(pos, rot);
        pos += speedVector;

        //Corner teleportation
        //Oben
        if (gameObject.transform.position.y > 9.51)
        {
            float x = gameObject.transform.position.x;
            float y = -9.5f;
            pos = new Vector3(x, y, 0);
            gameObject.transform.SetPositionAndRotation(pos, rot);
        }
        //Unten
        if (gameObject.transform.position.y < -9.51)
        {
            float x = gameObject.transform.position.x;
            float y = 9.5f;
            pos = new Vector3(x, y, 0);
            gameObject.transform.SetPositionAndRotation(pos, rot);
        }
        //Rechts
        if (gameObject.transform.position.x > 16.5)
        {
            float y = gameObject.transform.position.y;
            float x = -16.49f;
            pos = new Vector3(x, y, 0);
            gameObject.transform.SetPositionAndRotation(pos, rot);
        }
        //Links
        if (gameObject.transform.position.x < -16.5)
        {
            float y = gameObject.transform.position.y;
            float x = 16.49f;
            pos = new Vector3(x, y, 0);
            gameObject.transform.SetPositionAndRotation(pos, rot);
        }
    }

    private float randomTo(float max)
    {
        return UnityEngine.Random.Range(0f, max);
    }
}
