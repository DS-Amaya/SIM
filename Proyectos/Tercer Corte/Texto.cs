using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Texto : MonoBehaviour
{
    GameObject obj;

    public Text magni;
    public Text torc;

    void Start()
    {
        obj = GameObject.Find("Centro");
        magni.text = obj.GetComponent<Torque>().magnitud.ToString();
        torc.text = obj.GetComponent<Torque>().torque.ToString();
    }

    void Update()
    {
        magni.text = obj.GetComponent<Torque>().magnitud.ToString();
        torc.text = obj.GetComponent<Torque>().torque.magnitude.ToString();
    }
}
