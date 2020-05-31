using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{

    float _GRAVITYACCELERATION = -9.8f;
    public float fMass;
    float Density = 0.0f;
    float fSpeed;
    Vector3 fRadius;
    Color Color;
    Vector3 vGravity = new Vector3();
    Vector3 vPosition = new Vector3();
    public Vector3 vVelocity = new Vector3();
    Vector3 vForces = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        fRadius.x = Random.value * 1.3f;
        fRadius.y = fRadius.x;
        fRadius.z = fRadius.x;
        gameObject.GetComponent<Transform>().localScale = fRadius;

        Color.r = Random.Range(0f, 1f);
        Color.g = Random.Range(0f, 1f);
        Color.b = Random.Range(0f, 1f);
        gameObject.GetComponent<Renderer>().material.color = Color;

        fMass = Random.value * 20;
        vPosition.x = Random.Range(-10, 10) * 7;
        vPosition.y = Random.Range(5, 10) * 10;
        vPosition.z = Random.Range(-3, 3) * 7;
        vVelocity.x = 0;
        vVelocity.y = 0;
        vVelocity.z = 0;
        fSpeed = 0;
        vForces.x = 0.0f;
        vForces.y = 0.0f;
        vForces.z = 0.0f;

        vGravity.x = 0;
        vGravity.y = fMass * _GRAVITYACCELERATION;

    }

    // Update is called once per frame
    void Update()
    {
        CalcLoads();
        UpdateBodyEuler(0.01f);
    }


    public void CalcLoads()
    {
        // Reset forces:
        vForces.x = 0.0f;
        vForces.y = 0.0f;
        // Aggregate forces:
        vForces += vGravity;
    }

    public void UpdateBodyEuler(float dt)
    {
        Vector3 a;
        Vector3 dv;
        Vector3 ds;
        a = vForces / fMass; // Integrate equation of motion
        dv = a * dt;
        vVelocity += dv;
        ds = vVelocity * dt;
        if (gameObject.GetComponent<Transform>().position.y > 0.5f)
        {
            vPosition += ds;
            gameObject.GetComponent<Transform>().position = vPosition;
        }
        fSpeed = vVelocity.magnitude; // Misc. calculations
    }
}