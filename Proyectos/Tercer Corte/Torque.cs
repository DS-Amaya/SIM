using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Torque : MonoBehaviour
{
    public float masa, magnitud;

    Vector3 Fuerza;
    float r, I;
    public Vector3 torque;
    Vector3 posicionAngular, unitario;
    Vector3 aceleracionAngular;
    Vector3 w;
    float tiempo;
    Quaternion quaternion;
    GameObject Movable;
    LineRenderer lr;

    void Start()
    {
        w.x = 0;
        w.y = 0;
        w.z = 0;
        tiempo = 0.01f;
        Movable = GameObject.Find("ball");
        r = 10f;
    }


    void Update()
    {
        //obtiene la rotacion del objeto
        posicionAngular = gameObject.GetComponent<Transform>().rotation.eulerAngles;

        //obtiene la fuerza aplicada con el mouse
        Fuerza = Movable.GetComponent<Fuerza>().fuerza;
        //saca su magnitud
        magnitud = Fuerza.magnitude;
        //obtiene el vector unitario para sacar el angulo con el que se aplica la fuerza
        unitario = Fuerza.normalized;
        
        //Fuerza = magnitud de fuerza * sen(angulo)
        Fuerza.z = magnitud * unitario.z;
        //Fuerza = magnitud de fuerza * cos(angulo)
        Fuerza.x = magnitud * unitario.x;

        //torque = fuerza * distancia entre el centro de masa y el objeto
        torque = Fuerza * r;

        //momento de inercia
        I = (masa * Mathf.Pow(r, 2)) / 3;

        //aceleracion angular
        aceleracionAngular = torque / I;

        //aplica euler para obtener la velocidad angular (w) y la posicion angular (posicionAngular)
        w = w + aceleracionAngular * tiempo;
        posicionAngular = posicionAngular + w * tiempo;
        //convierte de vector3 a quaterniones
        quaternion = Quaternion.Euler(posicionAngular.x, posicionAngular.y, posicionAngular.z);
        //transforma la rotación del objeto
        gameObject.GetComponent<Transform>().rotation = quaternion;
    }

}
