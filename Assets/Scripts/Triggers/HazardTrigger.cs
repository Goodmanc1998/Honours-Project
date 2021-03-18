using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTrigger : MonoBehaviour
{

    public DevelopingHazard devHazard;

    private void Awake()
    {
        if(devHazard == null)
        {
            devHazard = GameObject.FindGameObjectWithTag("DevelopingHazard").GetComponent<DevelopingHazard>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision : " + other.name);

        if (other.gameObject.tag == "Player")
        {
            devHazard.ActivateHazard();
        }
    }
}
