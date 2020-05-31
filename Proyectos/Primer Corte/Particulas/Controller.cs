using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public int particleAmount;      //Cantidad de partículas
    public GameObject myPrefab;
    float a;
    float dt = 0.01f;
    private List<GameObject> lParticle = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < particleAmount; i++)
        {
           // a = Random.value*40;
           // GameObject g = Instantiate(myPrefab, new Vector3(100,100,100), Quaternion.identity);
           // a = g.GetComponent<Particle>().vVelocity.z;
            //Vector3 position = g.GetComponent<Transform>().position;
            //g.GetComponent<Particle>().SetPosition(Random.value * 100, Random.value * 100, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}   