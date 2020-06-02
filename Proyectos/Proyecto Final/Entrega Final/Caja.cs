using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caja : MonoBehaviour
{
	public float altura;
	public float ancho;
	public float profundidad;
	GameObject Drone;
	float radio, e;
	int motor;
	public Vector3 d;
	Vector3 PObj, PCubo, speed;
	void Start()
	{
		Drone = GameObject.Find("Drone");
		altura = (gameObject.GetComponent<Transform>().localScale.y) / 2;
		ancho = (gameObject.GetComponent<Transform>().localScale.x) / 2;
		profundidad = (gameObject.GetComponent<Transform>().localScale.z) / 2;
	}

	void Update()
	{
		speed = Drone.GetComponent<Total>().v;
		PObj = Drone.GetComponent<Transform>().position;
		PCubo = gameObject.GetComponent<Transform>().position;
		radio = Drone.GetComponent<Colision_pared>().Radio;
		e = 0.3f;
		motor = Drone.GetComponent<Controlador>().prendido;

		d.x = Mathf.Abs(PObj.x - PCubo.x);
		d.y = Mathf.Abs(PObj.y - PCubo.y);
		d.z = Mathf.Abs(PObj.z - PCubo.z);
		if (d.y <= altura + (radio - 5))
		{
			if (d.z <= profundidad + (radio - 5))
			{
				if (d.x <= ancho + (radio - 5))
				{
					if (motor == 1)
					{
						speed.x = -speed.x;
						speed.z = -speed.z;
						speed.y = -speed.y;
					}
					else if (speed.y <= 0)
					{
						speed.x = -e * speed.x;
						speed.z = -e * speed.z;
						speed.y = -e * speed.y;
					}

				}
			}
		}
		Drone.GetComponent<Total>().v = speed;
	}
}
