using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esferas2 : MonoBehaviour
{
    public Vector3 V;
    Vector3 P;
    float tiempo = 0.01f;
    Color Color;
    public float Radio = 0.6f;


    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.01f;
        tiempo = Time.fixedDeltaTime;
        Color.r = Random.Range(0f, 1f);
        Color.g = Random.Range(0f, 1f);
        Color.b = Random.Range(0f, 1f);
        gameObject.GetComponent<Renderer>().material.color = Color;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        P = gameObject.GetComponent<Transform>().position;
        P = P + V * tiempo;
        gameObject.GetComponent<Transform>().position = P;
    }
 }
