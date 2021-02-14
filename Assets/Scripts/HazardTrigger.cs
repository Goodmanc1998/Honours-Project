using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTrigger : MonoBehaviour
{

    DevelopingHazard devHazard;

    private void Awake()
    {
        if(devHazard != null)
        {
            devHazard = GameObject.FindGameObjectWithTag("DevelopingHazard").GetComponent<DevelopingHazard>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            devHazard.ActivateHazard();
        }
    }
}
