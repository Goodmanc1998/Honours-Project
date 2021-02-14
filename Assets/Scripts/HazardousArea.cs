using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousArea : Hazard
{

    public float checkTime = 0f;
    public bool looking = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(looking)
        {
            checkTime += Time.deltaTime;
        }
    }

    public void StartLookingArea()
    {
        looking = true;
        GetComponent<Renderer>().material.color = Color.blue;
    }

    public void StopLookingArea()
    {
        looking = false;
        GetComponent<Renderer>().material.color = Color.red;
    }
}
