using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragmentFlight : MonoBehaviour
{
    public float directionAngle;
    public Vector3 pos;
    public Vector3 speed;
    public float speedValue;
    private float speedX, speedY;
    void Start()
    {
        pos = gameObject.transform.position;
        directionAngle = UnityEngine.Random.Range(0, 360);
        speedX += -Mathf.Sin(directionAngle * Mathf.Deg2Rad) * speedValue;
        speedY += Mathf.Cos(directionAngle * Mathf.Deg2Rad) * speedValue;

        pos = gameObject.transform.position;
        speed = new Vector3(speedX, speedY, 0);
    }

    void Update()
    {
        float tempSpeedX = speedX * Time.deltaTime * 60;
        float tempSpeedY = speedY * Time.deltaTime * 60;
        speed = new Vector3(tempSpeedX, tempSpeedY, 0);
        pos += speed;
        transform.SetPositionAndRotation(pos, gameObject.transform.rotation);
    }
}
