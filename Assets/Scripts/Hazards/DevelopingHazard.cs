using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevelopingHazard : Hazard
{

    public float activeHazardTime = 0f;
    float maxHazardTime = 5f;

    public bool active = false;
    bool sent = false;

    // Start is called before the first frame update
    void Start()
    {
        currHazard = GameManager.Hazards.Developing;

        activeHazardTime = maxHazardTime;

    }

    // Update is called once per frame
    void Update()
    {

        if(active && !this.registered)
        {
            if(activeHazardTime >= 0)
            {
                activeHazardTime -= Time.deltaTime;
            }
        }

        if(this.registered && !sent)
        {
            sent = true;
            GameManager.Instance.UpdatePlayerScore(currHazard, Mathf.RoundToInt(activeHazardTime));
        }

    }

    public void ActivateHazard()
    {
        active = true;
    }
}
