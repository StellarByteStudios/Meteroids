using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFlight : MonoBehaviour
{
    public float speed = 0.15f;
    public Vector3 direction = new Vector3(0, 0, 0);
    public Vector3 speedVector = new Vector3(0, 0, 0);
    public Vector3 pos = new Vector3(0, 0, 0);
    public Quaternion rot = new Quaternion(0, 0, 0, 0);
    public float speedX, speedY;
    private GameObject ship;

    private void Start()
    {
        GameObject ship = GameObject.FindGameObjectWithTag("Ship");
        GameObject shipcontroller = GameObject.FindGameObjectWithTag("GameController");
        ShipControl shipControl = shipcontroller.GetComponent<ShipControl>();
        pos = new Vector3(ship.transform.position.x, ship.transform.position.y, ship.transform.position.z);
        rot = new Quaternion(ship.transform.rotation.x, ship.transform.rotation.y, ship.transform.rotation.z, ship.transform.rotation.w);


        //if (shipControl.speedX > 0.1f | shipControl.speedX < -0.1f) { speed = 0.18f; Debug.Log("X Speed erhöht"); }
        speedX += -Mathf.Sin(ship.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed * Time.deltaTime * 120;
        //speedX += -Mathf.Sin(ship.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed * 2;

        //if (shipControl.speedY > 0.1f | shipControl.speedY < -0.1f) { speed = 0.18f; Debug.Log("Y Speed erhöht"); }
        speedY += Mathf.Cos(ship.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed * Time.deltaTime * 120;
        //speedY += Mathf.Cos(ship.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * speed * 2;



        speedVector = new Vector3(speedX, speedY, 0);
        pos += speedVector * 4;
        speedVector += getSpeed();
        transform.SetPositionAndRotation(pos, rot);
    }
    void Update()
    {
        if (Time.deltaTime == 0)
        {
            return;
        }
        //float speedXtemp = speedX * Time.deltaTime * 60;
        //float speedYtemp = speedY * Time.deltaTime * 60;
        speedVector = new Vector3(speedX, speedY, 0);

        transform.SetPositionAndRotation(pos, rot);
        pos += speedVector;

        //Corner teleportation
        //Oben
        if (transform.position.y > 11)
        {
            float x = transform.position.x;
            float y = -10.99f;
            pos = new Vector3(x, y, 0);
            transform.SetPositionAndRotation(pos, rot);
        }
        //Unten
        if (transform.position.y < -11)
        {
            float x = transform.position.x;
            float y = 10.99f;
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
    public Vector3 getSpeed()
    {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
        ShipControl shipControl = controller.GetComponent<ShipControl>();
        return shipControl.speed;
    }
}
