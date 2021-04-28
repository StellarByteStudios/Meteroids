using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletFlight : MonoBehaviour
{
    public float speed = 0.15f;
    public Vector3 speedVector = new Vector3(0, 0, 0);
    public Vector3 pos = new Vector3(0, 0, 0);
    public Quaternion rot = new Quaternion(0, 0, 0, 0);
    public float speedX, speedY;

    private void Start()
    {

        pos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        rot = new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z, gameObject.transform.rotation.w);

        speedX += -Mathf.Sin(gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed * Time.deltaTime * 120;
        speedY += Mathf.Cos(gameObject.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed * Time.deltaTime * 120;

        speedVector = new Vector3(speedX, speedY, 0);
        pos += speedVector * 4;
        transform.SetPositionAndRotation(pos, rot);
    }
    void Update()
    {
        if (Time.deltaTime == 0)
        {
            return;
        }
        speedVector = new Vector3(speedX, speedY, 0);

        transform.SetPositionAndRotation(pos, rot);
        pos += speedVector;

        
    }
}
