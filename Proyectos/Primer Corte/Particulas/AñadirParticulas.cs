using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AñadirParticulas : MonoBehaviour
{

    public int particleAmount;      //Cantidad de partículas
    public GameObject myPrefab;
    float a;
    float dt = 0.01f;
    private List<GameObject> lParticle = new List<GameObject>();
    public void Añadir()
    {
        GameObject g = Instantiate(myPrefab, new Vector3(100, 100, 100), Quaternion.identity);
    }
}
