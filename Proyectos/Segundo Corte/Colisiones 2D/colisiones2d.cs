using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colisiones2d : MonoBehaviour
{
    public Text V1x;
    public Text V2x;
    public Text V1y;
    public Text V2y;

    public Text M_1;
    public Text M_2;

    public Text C_1;
    public Text C_2;

    public GameObject myPrefab;
    public List<GameObject> lEsferas = new List<GameObject>();
    float r, radio = 0.6f;
    float d;
    Vector3 P1, P2;
    Vector3 V1, V2, Vx1, Vx2;
    float V1f, V2f, Vp1, Vp2, Vn1, Vn2;
    public float CO1, CO2;
    public float MA1, MA2;
    float e;
    public Vector3 setV1, setV2;
    Vector3 b, Po1, Po2;
    float sumR, theta, res;
    // Start is called before the first frame update
    void Start()
    {
        Po1.x = 5;
        Po1.y = -4;
        Po2.x = -5;
        Po2.y = 4;

        for (int i = 0; i < 2; i++)
        {
            GameObject Esfera = Instantiate(myPrefab, new Vector3(i + 3, i + 3, 0), Quaternion.identity);
            lEsferas.Add(Esfera);
        }
     
        radio = lEsferas[0].GetComponent<Esferas2>().Radio;
        r = 2 * radio;
        lEsferas[0].GetComponent<Transform>().position = Po1;
        lEsferas[1].GetComponent<Transform>().position = Po2;
    }

    public void setAll() {
      
        setV1.x = float.Parse(V1x.text);
        setV2.x = float.Parse(V2x.text);
        setV1.y = float.Parse(V1y.text);
        setV2.y = float.Parse(V2y.text);

        MA1 = float.Parse(M_1.text);
        MA2 = float.Parse(M_2.text);
        CO1 = float.Parse(C_1.text);
        CO2 = float.Parse(C_2.text);

        lEsferas[0].GetComponent<Esferas2>().V = setV1;
        lEsferas[1].GetComponent<Esferas2>().V = setV2;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < lEsferas.Count - 1; i++)
        {

            for (int j = i + 1; j < lEsferas.Count; j++)
            {

                P1 = lEsferas[i].GetComponent<Transform>().position;
                P2 = lEsferas[j].GetComponent<Transform>().position;
                V1 = lEsferas[i].GetComponent<Esferas2>().V;
                V2 = lEsferas[j].GetComponent<Esferas2>().V;

                d = Mathf.Sqrt(Mathf.Pow(P1.x - P2.x, 2) + Mathf.Pow(P1.y - P2.y, 2));

                if (d <= r)
                {

                    b = P1 - P2;
                    b = b.normalized;

                    Vp1 = V1.x * b.x + V1.y * b.y;
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

                    lEsferas[i].GetComponent<Esferas2>().V = Vx1;
                    lEsferas[j].GetComponent<Esferas2>().V = Vx2;
                }


            }
        }

    }
}
