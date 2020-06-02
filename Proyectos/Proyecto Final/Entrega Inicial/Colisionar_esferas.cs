using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisionar_esferas : MonoBehaviour
{
    GameObject Drone;
    float r, radio = 0.6f;
    bool colision;
    float d;
    Vector3 P1, P2;
    public Vector3 V2;
    Vector3 V1, Vx1, Vx2;
    float V1f, V2f, Vp1, Vp2, Vn1, Vn2;
    float CO1, CO2;
    float MA1; 
    public float MA2;
    float e;
    Vector3 setV;
    Vector3 b;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.01f;
        Drone = GameObject.Find("Drone");
        radio = Drone.GetComponent<Col_Esfera>().Radio;
        r = 2 * radio;
        //e = Drone.GetComponent<Col_Esfera>().e;
        e = 0.5f;
        MA1 = Drone.GetComponent<Fly>().masa;
        V2.x = -20;
        V2.y = 0;
        V2.z = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {      
        colision = Drone.GetComponent<Fly>().colision;

        P1 = Drone.GetComponent<Transform>().position;
                P2 = gameObject.GetComponent<Transform>().position;
                V1 = Drone.GetComponent<Fly>().speed;               

                d = Mathf.Sqrt(Mathf.Pow(P1.x - P2.x, 2) + Mathf.Pow(P1.y - P2.y, 2));

                if (d <= r)
                {
                    b = P1 - P2;
                    b = b.normalized;

                    Vp1 = V1.x * b.x + V1.y * b.y;
                    Vn1 = -V1.x * b.y + V1.y * b.x;

                    Vp2 = V2.x * b.x + V2.y * b.y;
                    Vn2 = -V2.x * b.y + V2.y * b.x;                   

                    V1f = Vp1 * ((MA1 - e * MA2) / (MA1 + MA2)) + Vp2 * ((1 + e) * MA2 / (MA1 + MA2));
                    V2f = Vp2 * ((MA2 - e * MA1) / (MA1 + MA2)) + Vp1 * ((1 + e) * MA1 / (MA1 + MA2));

                    Vx1.x = V1f * b.x - Vn1 * b.y;
                    Vx1.y = V1f * b.y + Vn1 * b.x;

                    Vx2.x = V2f * b.x - Vn2 * b.y;
                    Vx2.y = V2f * b.y + Vn2 * b.x;

                Debug.Log("si");
                Drone.GetComponent<Fly>().speed = Vx1;
                V2 = Vx2;
                colision = true;
                Drone.GetComponent<Fly>().colision = colision;
        }

        P2 = P2 + V2 * Time.fixedDeltaTime;
        gameObject.GetComponent<Transform>().position = P2;
    

    }
}
