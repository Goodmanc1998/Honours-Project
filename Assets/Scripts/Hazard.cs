using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public bool seen = false;
    public bool registered = false;

    virtual public void SeenHazard()
    {
        if(!seen)
        {
            seen = true;
            GetComponent<Renderer>().material.color = Color.yellow;
        }
    }

    virtual public void RegisteredHazard()
    {
        if(!registered)
        {
            registered = true;
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
