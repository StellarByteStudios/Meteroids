using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteroidFly : MonoBehaviour
{
    public float speed = 0.009f;
    public Vector3 pos = new Vector3(0, 0, 0);
    public Quaternion rot = new Quaternion(0, 0, 0, 0);
    public Vector3 speedVector = new Vector3(0, 0, 0);
    private float speedX, speedY;

    void Start()
    {
        //speedX += -Mathf.Sin(Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad) * speed * Time.deltaTime * 120;
        //speedY += Mathf.Cos(Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad) * speed * Time.deltaTime * 120;
        
        speedX += -Mathf.Sin(Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad) * speed;
        speedY += Mathf.Cos(Random.Range(0.0f, 360.0f) * Mathf.Deg2Rad) * speed;

        pos = gameObject.transform.position;
        rot = gameObject.transform.rotation;
        speedVector = new Vector3(speedX, speedY, 0);
    }

    void Update()
    {
        if (Time.deltaTime == 0)
        {
            return;
        }
        
        float speedXtemp = speedX * Time.deltaTime * 120;
        float speedYtemp = speedY * Time.deltaTime * 120;
        speedVector = new Vector3(speedXtemp, speedYtemp, 0);

        transform.SetPositionAndRotation(pos, rot);
        pos += speedVector;

        //Corner teleportation
        //Oben
        if (transform.position.y > 10.5)
        {
            float x = transform.position.x;
            float y = -10.49f;
            pos = new Vector3(x, y, 0);
            transform.SetPositionAndRotation(pos, rot);
        }
        //Unten
        if (transform.position.y < -10.5)
        {
            float x = transform.position.x;
            float y = 10.49f;
            pos = new Vector3(x, y, 0);
            transform.SetPositionAndRotation(pos, rot);
        }
        //Rechts
        if (transform.position.x > 16)
        {
            float y = transform.position.y;
            float x = -15.99f;
            pos = new Vector3(x, y, 0);
            transform.SetPositionAndRotation(pos, rot);
        }
        //Links
        if (transform.position.x < -16)
        {
            float y = transform.position.y;
            float x = 15.99f;
            pos = new Vector3(x, y, 0);
            transform.SetPositionAndRotation(pos, rot);
        }
    }
}
