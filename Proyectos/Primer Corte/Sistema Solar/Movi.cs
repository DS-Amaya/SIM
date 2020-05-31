using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movi : MonoBehaviour
{
    public GameObject planeta1;
    public GameObject planeta2;

    float dt;

    void Start()
    {
        Time.fixedDeltaTime = 0.02f;
        dt = Time.fixedDeltaTime;
    }
    Vector3 fuerza(GameObject p1, GameObject p2)
    {
        float G =5f;
        Vector3 R = p1.transform.position - p2.transform.position;
        float R_magnitud = R.magnitude;
        Vector3 Rdireccion = R / R_magnitud;
        float F_magnitud = (G * p2.GetComponent<Planeta>().masaPlaneta * p1.GetComponent<Planeta>().masaPlaneta) / (R_magnitud * R_magnitud);
        Vector3 F_Vect = -F_magnitud * Rdireccion;

        return F_Vect;

    }

    void FixedUpdate()
    {
        Debug.Log(dt);
        Vector3 f1 = fuerza(planeta1, planeta2);
        Vector3 f2 = fuerza(planeta2, planeta1);
        planeta1.GetComponent<Planeta>().momento = planeta1.GetComponent<Planeta>().momento + f1*dt;
        planeta2.GetComponent<Planeta>().momento = planeta2.GetComponent<Planeta>().momento + (f2*dt);

        planeta1.GetComponent<Transform>().position = planeta1.GetComponent<Transform>().position + (planeta1.GetComponent<Planeta>().momento / planeta1.GetComponent<Planeta>().masaPlaneta) * dt;
        planeta2.GetComponent<Transform>().position = planeta2.GetComponent<Transform>().position + (planeta2.GetComponent<Planeta>().momento / planeta2.GetComponent<Planeta>().masaPlaneta) * dt;
    }
}
