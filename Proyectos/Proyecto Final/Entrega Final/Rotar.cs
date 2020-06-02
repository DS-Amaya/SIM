using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour
{
    Vector3 pitchyawroll;
    public bool w, a, s, d, e, q, reset;
    Quaternion rotationMin;
    Quaternion rotationMax;
    Quaternion rotation;

    void Start()
    {
        
    }

    void Update()
    {
        rotationMin = Quaternion.Euler(new Vector3(-5f, 0f, -5f));
        rotationMax = Quaternion.Euler(new Vector3(5f, 0f, 5f));       

        rotation = transform.rotation;

        q = gameObject.GetComponent<Total>().q;
        e = gameObject.GetComponent<Total>().e;

        a = gameObject.GetComponent<Total>().a;
        d = gameObject.GetComponent<Total>().d;

        w = gameObject.GetComponent<Total>().w;
        s = gameObject.GetComponent<Total>().s;

        reset = gameObject.GetComponent<Total>().reset;

        //camara
        if (Input.GetKey(KeyCode.O))
        {
            
           rotation.y += Quaternion.Euler(new Vector3(0f, 0.5f, 0f)).y;
          
        }

        if (Input.GetKey(KeyCode.P))
        {

            rotation.y -= Quaternion.Euler(new Vector3(0f, 0.5f, 0f)).y;

        }

        //subir
        if (s)
        {
            if (rotation.x < rotationMax.x)
            {
                rotation.x += Quaternion.Euler(new Vector3(0.5f, 0f, 0f)).x;
            }
        }
      if (w)
        {
            if (rotation.x > rotationMin.x)
            {
                rotation.x -= Quaternion.Euler(new Vector3(0.5f, 0f, 0f)).x;
            }
        }
        
          //lados
          if (a)
          {
               if (rotation.z < rotationMax.z)
                {
                     rotation.z += Quaternion.Euler(new Vector3(0f, 0f, 0.5f)).z;
                }
          }
          if (d)
          {
            if (rotation.z > rotationMin.z)
            {
                rotation.z -= Quaternion.Euler(new Vector3(0f, 0f, 0.5f)).z;
            }
        }

        //reset
        if (reset)
        {

            if (rotation.x < 0)
            {
                rotation.x += Quaternion.Euler(new Vector3(0.3f, 0f, 0f)).x;
            }
            if (rotation.x > 0)
            {
                rotation.x -= Quaternion.Euler(new Vector3(0.3f, 0f, 0f)).x;
            }

            if (rotation.z < 0)
            {
                rotation.z += Quaternion.Euler(new Vector3(0f, 0f, 0.3f)).z;
            }
            if (rotation.z > 0)
            {
                rotation.z -= Quaternion.Euler(new Vector3(0f, 0f, 0.3f)).z;
            }
        }
        

        transform.rotation = rotation;

    }
}
