using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
	public float altura;
	public float ancho;
	public float profundidad;
	GameObject Drone;
	float radio,e;
	bool motor;
	public Vector3 d;
	Vector3 PObj, PCubo, speed;
	void Start()
	{
		Drone = GameObject.Find("Drone");
		altura = (gameObject.GetComponent<Transform>().localScale.y)/2;
		ancho = (gameObject.GetComponent<Transform>().localScale.x)/2;
		profundidad = (gameObject.GetComponent<Transform>().localScale.z)/2;
	}

	void Update()
	{
        speed = Drone.GetComponent<Fly>().speed;     
        PObj = Drone.GetComponent<Transform>().position;
		PCubo = gameObject.GetComponent<Transform>().position;
		radio = Drone.GetComponent<Col_Esfera>().Radio;
		e = Drone.GetComponent<Fly>().e;
		motor = Drone.GetComponent<Fly>().motor;

		d.x = Mathf.Abs(PObj.x - PCubo.x);
		d.y = Mathf.Abs(PObj.y - PCubo.y);
		d.z = Mathf.Abs(PObj.z - PCubo.z);
		if (d.y <=  altura + (radio - 5)) {			
			if (d.z <= profundidad + radio) {
				if (d.x <= ancho + radio) {
					if (motor == true) {
						speed.x = -speed.x;
						speed.y = -speed.y;
					}
					else if (speed.y <= 0) {
						speed.x = -e*speed.x;
						speed.y = -e*speed.y;
					}
					
				}
			}			
		}	
		Drone.GetComponent<Fly>().speed = speed;
    }
}
