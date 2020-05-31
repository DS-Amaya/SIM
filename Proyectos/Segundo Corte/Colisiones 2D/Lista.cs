using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lista : MonoBehaviour
{
    public GameObject myPrefab;
    public List<GameObject> lEsferas = new List<GameObject>();
    float r, radio = 0.6f;
    float d;
    Vector3 P1, P2;
    Vector3 V1, V2, Vx1, Vx2; 
    float V1f, V2f, Vp1, Vp2, Vn1, Vn2;
    float CO1, CO2;
    float MA1, MA2;
    float e;
    Vector3 setV;
    Vector3 b;
    float sumR, theta, res;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject Esfera = Instantiate(myPrefab, new Vector3( i +1, i+1, 0), Quaternion.identity);
            setV.x = Random.value * 5;
            setV.y = Random.value * 5;
            Esfera.GetComponent<Esfera>().V = setV;
           
            lEsferas.Add(Esfera);
        }
      
        MA1 = 10f;
        MA2 = 10f;
        CO1 = 1f;
        CO2 = 1f;
        radio = lEsferas[0].GetComponent<Esfera>().Radio;
        r = 2 * radio;
    }

        // Update is called once per frame
        void Update()
    {
        for (int i = 0; i < lEsferas.Count - 1; i++) {
     
            for (int j = i + 1; j < lEsferas.Count; j++) {
              
                P1 = lEsferas[i].GetComponent<Transform>().position;
                P2 = lEsferas[j].GetComponent<Transform>().position;
                V1 = lEsferas[i].GetComponent<Esfera>().V;
                V2 = lEsferas[j].GetComponent<Esfera>().V;
               
                d = Mathf.Sqrt(Mathf.Pow(P1.x - P2.x, 2) + Mathf.Pow(P1.y - P2.y, 2));
           
                if (d <= r)
                {
                
                    b = P1 - P2;
                    b = b.normalized;
            
                    Vp1 = V1.x *b.x + V1.y * b.y;
                    Vn1 = -V1.x * b.y + V1.y * b.x;
                    Vp2 = V2.x * b.x + V2.y * b.y;
                    Vn2 = -V2.x * b.y + V2.y * b.x;

                    e = (CO1 + CO2) / 2;

                    V1f = Vp1 * ((MA1 - e * MA2) / (MA1 + MA2)) + Vp2 * ((1 + e) * MA2 / (MA1 + MA2));
                    V2f = Vp2 * ((MA2 - e * MA1) / (MA1 + MA2)) + Vp1 * ((1 + e) * MA1 / (MA1 + MA2));

                    Vx1.x = V1f * b.x - Vn1 * b.y;
                    Vx1.y = V1f * b.y + Vn1 * b.x;

                    Vx2.x = V2f * b.x - Vn2 * b.y;
                    Vx2.y = V2f * b.y + Vn2 * b.x;

                    lEsferas[i].GetComponent<Esfera>().V = Vx1;
                    lEsferas[j].GetComponent<Esfera>().V = Vx2;
                }


                }
            }             

        }
    public void Añadir()
    {
        GameObject Esfera = Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        setV.x = Random.value * 5;
        setV.y = Random.value * 5;
        Esfera.GetComponent<Esfera>().V = setV;

        lEsferas.Add(Esfera);
    }

}
