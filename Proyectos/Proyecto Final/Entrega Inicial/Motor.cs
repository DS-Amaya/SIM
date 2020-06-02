using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour
{
    public bool motor;
    public GameObject music;
    int on_off;
  
    // Start is called before the first frame update
    void Start()
    {
        on_off = 1;
        //music = GameObject.Find("Music");
        music.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            on_off++;
            if ((on_off % 2) == 0)
            {
                motor = true;
                music.SetActive(true);
                Debug.Log("Motor encendido.");
            }
            else
            {
                motor = false;
                music.SetActive(false);
                Debug.Log("Motor apagado.");

            }

        }     
    }
}
