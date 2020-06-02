using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T4 : MonoBehaviour
{
    public int encendido;
    public float magnitud;
    float masa;
    public Vector3 Fuerza;
    float r, Iner;
    Vector3 aceleracion;
    Vector3 tor;
    Vector3 posicionAngular, unitario;
    public Vector3 angular;
    public Vector3 w;
    float tiempo;
    Quaternion quaternion;

    void Start()
    {
        w.x = 0;
        w.y = 0;
        w.z = 0;
        Time.fixedDeltaTime = 0.01f;
        tiempo = Time.fixedDeltaTime;
        r = 1.1f;
        masa = 5f;
        encendido = 0;
    }


    void FixedUpdate()
    {
        posicionAngular = gameObject.GetComponent<Transform>().rotation.eulerAngles;
        magnitud = Fuerza.magnitude;
        tor = Fuerza * r;
        Iner = 0.5f;
        angular = tor / Iner;

        if (encendido == 0)
        {
            if (w.y != 0)
            {
                if (w.y > 0)
                {
                    w.y = w.y - 1;
                }
                if (w.y < 0)
                {
                    w.y = w.y + 1;
                }
                if (w.y > -1 && w.y < 1)
                {
                    w.y = 0;
                }
            }
        }
        else
        {
            if (w.y < 300)
            {
                w = w + angular * tiempo;               
            }
            
        }

        posicionAngular = posicionAngular + w * tiempo;
        quaternion = Quaternion.Euler(-90.0f, posicionAngular.y, 0.0f);
        gameObject.GetComponent<Transform>().rotation = quaternion;
    }
}
