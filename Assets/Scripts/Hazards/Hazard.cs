using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public bool seen = false;
    public bool registered = false;

    public GameManager.Hazards currHazard;

    private void Awake()
    { 
        currHazard = GameManager.Hazards.Possible;
    }

    virtual public void SeenHazard()
    {
        if(!seen)
        {
            seen = true;

            GameManager.Instance.UpdatePlayerScore(currHazard, 2);
        }
    }

    virtual public void RegisteredHazard()
    {
        if(!registered)
        {
            registered = true;
            GameManager.Instance.UpdatePlayerScore(currHazard, 3);
        }
    }


}
