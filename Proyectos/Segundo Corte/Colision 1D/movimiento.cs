using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento :  MonoBehaviour
{
    public float MA1;
    public float MA2;
    public float CO1;
    public float CO2;
    public Vector3 V;
    Vector3 V2;
    public Vector3 P;
    Vector3 PM1;
    Vector3 Vx;
    float e;
    public float D;
   // float Masa2;
    float Radio;
    float R;
    float tiempo = 0.01f;
   public  float contador = 0;
    GameObject M1;
    // Start is called before the first frame update
    void Start()
    {
        Vx.x = 0;
        Vx.y = 0;
        Vx.z = 0;
        Radio = 0.5f;
        M1 = GameObject.Find("Esfera +");
        R = 2 * Radio;
      

    }

    // Update is called once per frame
    void Update()
    {
        P = gameObject.GetComponent<Transform>().position;
        PM1 = M1.GetComponent<Transform>().position;
        V2 = M1.GetComponent<mov_2>().V;
        D = Mathf.Abs(P.x - PM1.x);

        if (D <= (R + 0.1f))
        {
            contador++;
        }
        if(contador==1)
        {
            e = (CO1 + CO2) / 2;
            Vx = V * ((MA1 - e * MA2) / (MA1 + MA2)) + V2 * (((1 + e) * MA2) / (MA1 + MA2));
        }
        if(Vx.x ==0)
        {
            P = P + V * tiempo;
        }
        else
        {
            P = P + Vx * tiempo;
        }
 
        gameObject.GetComponent<Transform>().position = P;
    }
}
