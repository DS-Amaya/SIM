using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : MonoBehaviour
{
    public Vector3 axis;
    public float rotationsPerSecond;
    float tiempo;
    GameObject Drone;
    Vector3 py;
    bool motor;
   // float a;
    
    void Start()
    {    
    Time.fixedDeltaTime = 0.01f;
    tiempo = Time.fixedDeltaTime;
    //a = 1f;
    axis.z = 1;
    rotationsPerSecond = 0.5f;
    Drone = GameObject.Find("Drone");

    }  
   
    void Update()
    {
        motor = Drone.GetComponent<Motor>().motor;
        if (motor == true)
        {
            /*py = gameObject.GetComponent<Transform>().position;
            if (py.y <= 1.0f)
            {
                if (rotationsPerSecond <= 0.5f)
                {
                    rotationsPerSecond = rotationsPerSecond + 0.1f;
                }
                var angle = 360 * rotationsPerSecond * Time.deltaTime;
                transform.Rotate(axis, angle);
            }
            else
            {
                if (rotationsPerSecond <= 1.5f)
                {
                    rotationsPerSecond = rotationsPerSecond + 0.1f;
                }
                var angle = 360 * rotationsPerSecond * Time.deltaTime;
                transform.Rotate(axis, angle);
            }
            //rotationsPerSecond = rotationsPerSecond + a * tiempo;
*/
        }     

    }
}
