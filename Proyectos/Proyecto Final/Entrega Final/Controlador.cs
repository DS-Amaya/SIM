using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlador : MonoBehaviour
{
    public int prendido;
    GameObject H1, H2, H3, H4;
    float tiempo;
    string inputString;
    public Text motor;
    public Text velocidad;
    public Text movimiento;
    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = 0.01f;
        tiempo = Time.fixedDeltaTime;
        prendido = 0;

        H1 = GameObject.Find("1");
        H2 = GameObject.Find("2");
        H3 = GameObject.Find("3");
        H4 = GameObject.Find("4");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocidad.text = gameObject.GetComponent<Total>().v.magnitude.ToString();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            if (prendido == 0)
            {
                motor.text = "encendido";
                prendido = 1;
                H1.GetComponent<T1>().encendido = prendido;
                H2.GetComponent<T2>().encendido = prendido;
                H3.GetComponent<T3>().encendido = prendido;
                H4.GetComponent<T4>().encendido = prendido;
                gameObject.GetComponent<Total>().encendido = prendido;
               
                H1.GetComponent<T1>().Fuerza.y = 10;
                H2.GetComponent<T2>().Fuerza.y = -10;
                H3.GetComponent<T3>().Fuerza.y = -10;
                H4.GetComponent<T4>().Fuerza.y = 10;
            }
            else
            {
                prendido = 0;
                motor.text = "apagado";
                H1.GetComponent<T1>().encendido = prendido;
                H2.GetComponent<T2>().encendido = prendido;
                H3.GetComponent<T3>().encendido = prendido;
                H4.GetComponent<T4>().encendido = prendido;
                gameObject.GetComponent<Total>().encendido = prendido;
            }

        }

        if (Input.anyKey)
        {
            switch (Input.inputString)
            {
                case "q":
                    movimiento.text = "q : elevarse";
                    H1.GetComponent<T1>().Fuerza.y = 10;
                    H2.GetComponent<T2>().Fuerza.y = -10;
                    H3.GetComponent<T3>().Fuerza.y = -10;
                    H4.GetComponent<T4>().Fuerza.y = 10;

                    gameObject.GetComponent<Total>().q = true;
                    gameObject.GetComponent<Total>().e = false;

                    gameObject.GetComponent<Total>().a = false;
                    gameObject.GetComponent<Total>().d = false;

                    gameObject.GetComponent<Total>().w = false;
                    gameObject.GetComponent<Total>().s = false;

                    gameObject.GetComponent<Total>().reset = false;

                    break;


                case "e":
                    movimiento.text = "e : descender";
                    H1.GetComponent<T1>().Fuerza.y = 11;
                    H2.GetComponent<T2>().Fuerza.y = -10;
                    H3.GetComponent<T3>().Fuerza.y = -11;
                    H4.GetComponent<T4>().Fuerza.y = 10;

                    gameObject.GetComponent<Total>().e = true;
                    gameObject.GetComponent<Total>().q = false;

                    gameObject.GetComponent<Total>().a = false;
                    gameObject.GetComponent<Total>().d = false;

                    gameObject.GetComponent<Total>().w = false;
                    gameObject.GetComponent<Total>().s = false;

                    gameObject.GetComponent<Total>().reset = false;

                    break;

                case "a":
                    movimiento.text = "a : izquierda";
                    H1.GetComponent<T1>().Fuerza.y = 11;
                    H2.GetComponent<T2>().Fuerza.y = -10;
                    H3.GetComponent<T3>().Fuerza.y = -10;
                    H4.GetComponent<T4>().Fuerza.y = 10;

                    gameObject.GetComponent<Total>().e = false;
                    gameObject.GetComponent<Total>().q = false;

                    gameObject.GetComponent<Total>().a = true;
                    gameObject.GetComponent<Total>().d = false;

                    gameObject.GetComponent<Total>().w = false;
                    gameObject.GetComponent<Total>().s = false;

                    gameObject.GetComponent<Total>().reset = false;

                    break;

                case "d":
                    movimiento.text = "d : derecha";
                    H1.GetComponent<T1>().Fuerza.y = 10;
                    H2.GetComponent<T2>().Fuerza.y = -10;
                    H3.GetComponent<T3>().Fuerza.y = -11;
                    H4.GetComponent<T4>().Fuerza.y = 10;

                    gameObject.GetComponent<Total>().e = false;
                    gameObject.GetComponent<Total>().q = false;

                    gameObject.GetComponent<Total>().a = false;
                    gameObject.GetComponent<Total>().d = true;

                    gameObject.GetComponent<Total>().w = false;
                    gameObject.GetComponent<Total>().s = false;

                    gameObject.GetComponent<Total>().reset = false;

                    break;

                case "w":
                    movimiento.text = "w : adelante";
                    H1.GetComponent<T1>().Fuerza.y = 10;
                    H2.GetComponent<T2>().Fuerza.y = -10;
                    H3.GetComponent<T3>().Fuerza.y = -10;
                    H4.GetComponent<T4>().Fuerza.y = 11;

                    gameObject.GetComponent<Total>().e = false;
                    gameObject.GetComponent<Total>().q = false;

                    gameObject.GetComponent<Total>().a = false;
                    gameObject.GetComponent<Total>().d = false;

                    gameObject.GetComponent<Total>().w = true;
                    gameObject.GetComponent<Total>().s = false;

                    gameObject.GetComponent<Total>().reset = false;

                    break;

                case "s":
                    movimiento.text = "s : atras";
                    H1.GetComponent<T1>().Fuerza.y = 10;
                    H2.GetComponent<T2>().Fuerza.y = -11;
                    H3.GetComponent<T3>().Fuerza.y = -10;
                    H4.GetComponent<T4>().Fuerza.y = 10;

                    gameObject.GetComponent<Total>().e = false;
                    gameObject.GetComponent<Total>().q = false;

                    gameObject.GetComponent<Total>().a = false;
                    gameObject.GetComponent<Total>().d = false;

                    gameObject.GetComponent<Total>().w = false;
                    gameObject.GetComponent<Total>().s = true;

                    gameObject.GetComponent<Total>().reset = false;

                    break;

                default:
                    break;

            }

        }
        else 
        {
            movimiento.text = "estático";
            H1.GetComponent<T1>().Fuerza.y = 10;
            H2.GetComponent<T2>().Fuerza.y = -10;
            H3.GetComponent<T3>().Fuerza.y = -10;
            H4.GetComponent<T4>().Fuerza.y = 10;

            gameObject.GetComponent<Total>().e = false;
            gameObject.GetComponent<Total>().q = false;

            gameObject.GetComponent<Total>().a = false;
            gameObject.GetComponent<Total>().d = false;

            gameObject.GetComponent<Total>().w = false;
            gameObject.GetComponent<Total>().s = false;
            gameObject.GetComponent<Total>().reset = true;
        }
    }
}