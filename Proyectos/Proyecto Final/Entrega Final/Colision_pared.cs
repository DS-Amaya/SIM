using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision_pared : MonoBehaviour
{
    public Vector3 P, speed, V;
    float Vp1, Vp2, V1f;
    public float Radio = 8f;
    float ancho, alto, profundidad;
    public float e;
    GameObject Drone;
    void Start()
    {
        Drone = GameObject.Find("Drone");
        ancho = 100f;
        alto = 100f;
        profundidad = 100f;
        e = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        speed = Drone.GetComponent<Total>().v;
        P = gameObject.GetComponent<Transform>().position;


        //Borde x
        if ((P.x + Radio) >= ancho)
        {
            speed.x = -speed.x;
            Debug.Log("derecha");
        }
        //Borde -x
        if ((P.x - Radio) <= -ancho)
        {
            speed.x = -speed.x;
            Debug.Log("izda");
        }
        //Borde y
        if ((P.y + Radio) >= alto)
        {
            speed.y = -speed.y;
        }
        //Borde -y
        if ((P.y + Radio) <= 0)
        {
            speed.y = -speed.y;
        }


        //Borde z
        if ((P.z + Radio) >= profundidad)
        {
            speed.z = -speed.z;
            Debug.Log("z");

        }
        //Borde -z
        if ((P.z - Radio) <= -profundidad)
        {
            speed.z = -speed.z;
            Debug.Log("menosz");
        }
        Drone.GetComponent<Total>().v = speed;

    }
}
