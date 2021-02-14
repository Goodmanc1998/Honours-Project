using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopingHazard : Hazard
{

    public float activeHazardTime = 0f;
    public float maxHazardTime = 0f;

    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(GetComponent<Renderer>().isVisible)
        {
            active = true;
        }

        if(active && !this.registered)
        {
            if(activeHazardTime <= maxHazardTime)
            {
                activeHazardTime += Time.deltaTime;
            }
        }
    }

    public void ActivateHazard()
    {
        active = true;
    }
}
