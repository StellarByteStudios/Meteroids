using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public float speedMod = 1f;
    public Vector3 pos = new Vector3(0, 0, 0);
    public Quaternion rot = new Quaternion(0, 0, 0, 0);
    public Vector3 speed;
    public float decay = 0.99f;
    public float shipZ;
    public float speedX = 0;
    public float speedY = 0;

    private float turnSpeed;
    private float turnMod = 300;
    private GameObject ship;
    private float Xtra, Ytra;
    


    void Update()
    {
        //Anhalten bei Spielpause
        if (Time.deltaTime == 0)
        {
            return;
        }

        //Schiff und seine Rotation finden
        ship = GameObject.FindGameObjectWithTag("Ship");
        shipZ = Mathf.Cos(ship.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);
        
        //Rotation
        turnSpeed = -Input.GetAxis("Horizontal") * turnMod * Time.deltaTime;
        ship.transform.Rotate(0, 0, turnSpeed);


        //Speed
        Xtra = Math.Abs(speedX);
        Ytra = Math.Abs(speedY);
        
        //Grenzfallsicherung: Schiff soll nicht zu schnell werden und es bleibt irgendwann stehen
        if (Xtra < 0.002f)
        {
            Xtra = 0.002f;
        }

        if (Ytra < 0.002f)
        {
            Ytra = 0.002f;
        }

        if (Xtra > 0.3f)
        {
            Xtra = 1f;
        }

        if (Ytra > 0.3f)
        {
            Ytra = 1f;
        }

        //Antriebsgeräusch
        if(Input.GetAxis("Jump") != 0)
        {
            FindObjectOfType<AudioManager>().Play("Ship Thrust");
            ship.GetComponent<SpriteAnimator>().animationOn = true;
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("Ship Thrust");
            ship.GetComponent<SpriteAnimator>().animationOn = false;
        }

        speedX += -Mathf.Sin(ship.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * Input.GetAxis("Jump") * (speedMod / (Xtra * Xtra * Xtra + 0.02f * 120)) * Time.deltaTime;
        speedY +=  Mathf.Cos(ship.transform.rotation.eulerAngles.z * Mathf.Deg2Rad) * Input.GetAxis("Jump") * (speedMod / (Ytra * Ytra * Ytra + 0.02f * 120)) * Time.deltaTime;


        speed = new Vector3(speedX, speedY, 0);
        pos += speed;
        Quaternion rot = new Quaternion(ship.transform.rotation.x, ship.transform.rotation.y, ship.transform.rotation.z, ship.transform.rotation.w);
        ship.transform.SetPositionAndRotation(pos, rot);

        
        speedX *= (decay - Xtra/15);
        speedY *= (decay - Ytra/15);

        if (speedX < 0.003 && speedX > -0.003 && Input.GetAxis("Jump") == 0)
        {
            speedX = 0.0f;
        }
        if (speedY < 0.003 && speedY > -0.003 && Input.GetAxis("Jump") == 0)
        {
            speedY = 0.0f;
        }

        //Corner teleportation
        //Oben
        if (ship.transform.position.y > 10.5)
        {
            float x = ship.transform.position.x;
            float y = -10.49f;
            pos = new Vector3(x, y, 0);
            ship.transform.SetPositionAndRotation(pos, rot);
        }
        //Unten
        if (ship.transform.position.y < -10.5)
        {
            float x = ship.transform.position.x;
            float y = 10.49f;
            pos = new Vector3(x, y, 0);
            ship.transform.SetPositionAndRotation(pos, rot);
        }
        //Rechts
        if (ship.transform.position.x > 16.5)
        {
            float y = ship.transform.position.y;
            float x = -16.49f;
            pos = new Vector3(x, y, 0);
            ship.transform.SetPositionAndRotation(pos, rot);
        }
        //Links
        if (ship.transform.position.x < -16.5)
        {
            float y = ship.transform.position.y;
            float x = 16.49f;
            pos = new Vector3(x, y, 0);
            ship.transform.SetPositionAndRotation(pos, rot);
        }
    }

    public void resetPosAndSpeed()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        pos = new Vector3(0, 0, 0);
        rot = new Quaternion(0, 0, 0, 0);
        speed = new Vector3(0, 0, 0);
        speedX = 0;
        speedY = 0;
        ship.transform.SetPositionAndRotation(pos, rot);
    }
}
