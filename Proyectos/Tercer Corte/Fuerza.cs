using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuerza : MonoBehaviour
{
    Vector3 posicionInicial, posicionFinal, posicionPelota;
    public Vector3 fuerza;
    float distance = 20;
    public float r;
    private LineRenderer lr;
    private LineRenderer lrforce;
    GameObject ancla;
    void Start() {
        posicionInicial = gameObject.GetComponent<Transform>().position;       
        ancla = GameObject.Find("Centro");
        lr = ancla.GetComponent<LineRenderer>();
        lrforce = gameObject.GetComponent<LineRenderer>();
        InvisibleLine();
    }
    void OnMouseDrag()
    {
        //hace la linea que muestra la fuerza con la que se va a realizar el torque
        Vector3[] positionsforceapplied = new Vector3[2];
        SetLineRendererPosition();
        VisibleLine();
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 ObjPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        positionsforceapplied[0] = posicionPelota;
        positionsforceapplied[1] = ObjPosition;
        lrforce.SetPositions(positionsforceapplied);
    }

    void OnMouseUp() 
    {
        //obtencion del vector fuerza
        SetLineRendererPosition();
        posicionFinal = gameObject.GetComponent<Transform>().position;
        fuerza = lrforce.GetPosition(1) - posicionPelota;
        r = Mathf.Sqrt(Mathf.Pow(lrforce.GetPosition(0).x - posicionPelota.x, 2) + Mathf.Pow(lrforce.GetPosition(0).x - posicionPelota.x, 2)); 
        InvisibleLine();

    }

    void OnMouseDown() 
    {
        posicionPelota = gameObject.GetComponent<Transform>().position;
    }

    void SetLineRendererPosition()
    {
        Vector3[] positions = new Vector3[2];
      
        positions[0] = ancla.GetComponent<Transform>().position;
        positions[1] = gameObject.GetComponent<Transform>().position;
        lr.SetPositions(positions);     
    }

    void InvisibleLine()
    {
        float alpha = 0.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lrforce.colorGradient = gradient;
    }
    void VisibleLine() 
    {
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
           new GradientColorKey[] { new GradientColorKey(Color.green, 0.0f), new GradientColorKey(Color.red, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lrforce.colorGradient = gradient;
    }
}
