using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Total : MonoBehaviour
{
    GameObject H1, H2, H3, H4;
    Vector3 w1, w2, w3, w4;
    public Vector3 FT, FD, FN, torque, ac;
    public Vector3  v, posicion, rotacion;
    public float mw1, mw2, mw3, mw4;
    float L, k, g, masa, radio, Paire, Area;
    public float b;
    float tiempo, radio2;
    public int encendido;
    public int habilitar;
    public bool w, a, s, d, e, q, reset;

    void Start()
    {
        L = 2.5f;
        k = 0.05f;
        b = 0.3f;
        g = -9.8f;
        masa = 20f;
        radio = 5f;
        Paire = 1.1f;
        Area = 50f;
        Time.fixedDeltaTime = 0.01f;
        tiempo = Time.fixedDeltaTime;
        habilitar = 0;
        H1 = GameObject.Find("1");
        H2 = GameObject.Find("2");
        H3 = GameObject.Find("3");
        H4 = GameObject.Find("4");
        q = a = e = d = s= w = reset = false;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        posicion = gameObject.GetComponent<Transform>().position;
        radio2 = gameObject.GetComponent<Colision_pared>().Radio;

        w1 = H1.GetComponent<T1>().w;
        mw1 = w1.magnitude;

        w2 = H2.GetComponent<T2>().w;
        mw2 = w2.magnitude;

        w3 = H3.GetComponent<T3>().w;
        mw3 = w3.magnitude;

        w4 = H4.GetComponent<T4>().w;
        mw4 = w4.magnitude;

        if (encendido == 0)
        {
            FN.y = masa * g;
            FD.y = 0.5f * (Paire * b * Area * Mathf.Pow(radio, 2));

            FT = FN - FD;
            ac = FT / masa;
            v.x = 0;
            v.z = 0;
            posicion = gameObject.GetComponent<Transform>().position;           
            if ((posicion.y - (radio2 - 5)) <= 0 && (v.y <= 0))
                {
                    v.y = -0.3f * v.y;
                }
                else
                {
                    v = v + ac * tiempo;
                }                 
            posicion = posicion + v * tiempo;
            gameObject.GetComponent<Transform>().position = posicion;
        
        }
        else 
        {         
            if (q)
            {
                mw1 = mw2 = mw3 = mw4;
                b = 0.3f;
                torque.x = L * k * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw3, 2));
                torque.z = L * k * (Mathf.Pow(mw2, 2) - Mathf.Pow(mw4, 2));
                torque.y = b * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw2, 2) + Mathf.Pow(mw3, 2) - Mathf.Pow(mw4, 2));

                FN.y = masa * g;
                FD.y = 0.5f * (Paire * b * Area * Mathf.Pow(radio, 2));
                FT = torque + FN + FD;
                ac = FT / masa;
                ac.z = 0;
                v = v + ac * tiempo;
                posicion = posicion + v * tiempo;
            }

            if (e)
            {
                b = 0.03f;
                mw1 = mw3 = mw2 + 1;
                torque.x = L * k * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw3, 2));
                torque.z = L * k * (Mathf.Pow(mw2, 2) - Mathf.Pow(mw4, 2));
                torque.y = b * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw2, 2) + Mathf.Pow(mw3, 2) - Mathf.Pow(mw4, 2));

                FN.y = masa * g;
                FD.y = 0.5f * (Paire * b * Area * Mathf.Pow(radio, 2));
                FT = torque + FN + FD;
                ac = FT / masa;

                ac.z = 0;
                v = v + ac * tiempo;
                posicion = posicion + v * tiempo;
            }

            if (a)
            {
                b = 0.03f;
                mw1 = mw3 + 1;
                torque.x = L * k * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw3, 2));
                torque.z = L * k * (Mathf.Pow(mw2, 2) - Mathf.Pow(mw4, 2));
                torque.y = b * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw2, 2) + Mathf.Pow(mw3, 2) - Mathf.Pow(mw4, 2));

                FN.y = masa * g;
                FD.y = 0.5f * (Paire * b * Area * Mathf.Pow(radio, 2));
                FT = torque + FN + FD;
                ac = FT / masa;
                ac.y = 0;
                v = v + ac * tiempo;
                posicion = posicion + v * tiempo;               
            }

            if (d)
            {
                b = 0.03f;
                mw3 = mw1 + 1;
                torque.x = L * k * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw3, 2));
                torque.z = L * k * (Mathf.Pow(mw2, 2) - Mathf.Pow(mw4, 2));
                torque.y = b * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw2, 2) + Mathf.Pow(mw3, 2) - Mathf.Pow(mw4, 2));

                FN.y = masa * g;
                FD.y = 0.5f * (Paire * b * Area * Mathf.Pow(radio, 2));
                FT = torque + FN + FD;
                ac = FT / masa;
                ac.y = 0;
                v = v + ac * tiempo;
                posicion = posicion + v * tiempo;
            }

            if (w)
            {
                b = 0.03f;
                mw4 = mw2 + 1;
                torque.x = L * k * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw3, 2));
                torque.z = L * k * (Mathf.Pow(mw2, 2) - Mathf.Pow(mw4, 2));
                torque.y = b * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw2, 2) + Mathf.Pow(mw3, 2) - Mathf.Pow(mw4, 2));

                FN.y = masa * g;
                FD.y = 0.5f * (Paire * b * Area * Mathf.Pow(radio, 2));
                FT = torque + FN + FD;
                ac = FT / masa;
                ac.y = 0;
                v = v + ac * tiempo;
                posicion = posicion + v * tiempo;
            }


            if (s)
            {
                b = 0.03f;
                mw2 = mw4 + 1;
                torque.x = L * k * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw3, 2));
                torque.z = L * k * (Mathf.Pow(mw2, 2) - Mathf.Pow(mw4, 2));
                torque.y = b * (Mathf.Pow(mw1, 2) - Mathf.Pow(mw2, 2) + Mathf.Pow(mw3, 2) - Mathf.Pow(mw4, 2));

                FN.y = masa * g;
                FD.y = 0.5f * (Paire * b * Area * Mathf.Pow(radio, 2));
                FT = torque + FN + FD;
                ac = FT / masa;
                ac.y = 0;
                v = v + ac * tiempo;
                posicion = posicion + v * tiempo;
            }

            if (reset)
            {
                ac.x = ac.y = ac.z = 0;
                torque.x = torque.y = torque.z = 0;
                v.x = v.y = v.z = 0;
                FN.y = FN.x = FN.z = 0;
                FD.y = FD.x = FD.z = 0;
                FT.y = FT.x = FT.z = 0;
              
            }

        }      

        gameObject.GetComponent<Transform>().position = posicion;     
    }
}
