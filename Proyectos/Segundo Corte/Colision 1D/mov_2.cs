using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov_2 : MonoBehaviour
{
    public float MA1;
    public float MA2;
    public float CO1;
    public float CO2;
    public Vector3 V;
    Vector3 V3;
    public Vector3 P1;
    Vector3 PM1;
    private Vector3 Vx1;
   //public float Masa;
   // public float coeficient;
    float e;
    float D1;
   // float Masa2;
    float Radio;
    float R1;
    float tiempo = 0.01f;
    public float contador = 0;
    GameObject M2;
    // Start is called before the first frame update
    void Start()
    {
        Vx1.x = 0;
        Vx1.y = 0;
        Vx1.z = 0;
        Radio = 0.5f;
        M2 = GameObject.Find("Esfera -");
        //Masa2 = M2.GetComponent<movimiento>().Masa;
        R1 = 2 * Radio;
        //V.x = VE2;
    }

    // Update is called once per frame
    void Update()
    {
        P1 = gameObject.GetComponent<Transform>().position;
        PM1 = M2.GetComponent<Transform>().position;
        V3 = M2.GetComponent<movimiento>().V;
        D1 = Mathf.Abs(PM1.x - P1.x);

        if (D1 <= (R1 + 0.1f))
        {
            contador++;
        }
        if (contador == 1)
        {
            e = (CO1+CO2) / 2;
            Vx1 = V * ((MA2 - e * MA1) / (MA2 + MA1)) + V3 * (((1 + e) * MA1) / (MA2 + MA1));
        }
        if (Vx1.x == 0)
        {
            P1 = P1 + V * tiempo;
        }
        else
        {
            P1 = P1 + Vx1 * tiempo;
        }

        gameObject.GetComponent<Transform>().position = P1;
    }
}
