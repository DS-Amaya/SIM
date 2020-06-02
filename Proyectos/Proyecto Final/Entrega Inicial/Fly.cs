using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Vector3 speed;
    public Vector3 acceleration;
    public bool colision;
    Vector3 positionObj;
    
    float g = 9.8f;
    public bool motor;
    public float masa;
    float aceleracion; 
    public float e;
    float radio;
    /*float lift;
    float mass;
    float weight;
    float c;
    float densityAir;
    float area;
    */
    void Start()
    {/*
        mass = 10.0f;
        weight = mass * g;
        c = 0.85f;
        densityAir = 1.225f;
        area = 0.3f;*/
        masa = 25f;
        e = 0.3f;
        Time.fixedDeltaTime = 0.01f;
    }

    void FixedUpdate()
    {
        radio = gameObject.GetComponent<Col_Esfera>().Radio;
        motor = gameObject.GetComponent<Motor>().motor;
        if (motor == true) {
            //Movimiento horizontal
            if (Input.GetKey(KeyCode.Tab))
            {
                if (speed.x <= 30f)
                {
                    speed.x = speed.x + acceleration.x * Time.fixedDeltaTime;
                }
                transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed.x);
                colision = false;
            }         

            //Movimiento vertical
            if (Input.GetKey(KeyCode.Space))
            {
                positionObj = gameObject.GetComponent<Transform>().position;

                if (speed.y <= 30f)
                { speed.y = speed.y + g * Time.fixedDeltaTime; }
                if (positionObj.y - radio < -radio)
                {
                    speed.y = -speed.y;
                }

                transform.Translate(0, Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed.y, 0);
                colision = false;
            }
           
            transform.Rotate(0.0f, Input.GetAxis("Horizontal"), 0.0f);
        }  
        else {
            speed.x = 0;
            aceleracion = -g;
            positionObj = gameObject.GetComponent<Transform>().position;

            if ((positionObj.y - radio) <= 0 && (speed.y <= 0))
            {
                Debug.Log(speed);
                speed.y = -e * speed.y;
            }
            else {
                speed.y += aceleracion * Time.fixedDeltaTime;
            }            
            positionObj += speed * Time.fixedDeltaTime;
            gameObject.GetComponent<Transform>().position = positionObj;
        }


        //colision
        if (colision == true)
        {
            positionObj = gameObject.GetComponent<Transform>().position;
            if (positionObj.y - radio < -radio)
            {
                speed.y = -speed.y;
            }
            positionObj = positionObj + speed * Time.fixedDeltaTime;
            gameObject.GetComponent<Transform>().position = positionObj;
            Debug.Log("colision");
        }
    }
}

