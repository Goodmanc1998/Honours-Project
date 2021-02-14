using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDirectionChecker : MonoBehaviour
{

    public Transform cameraTransform;

    [Range(0, 1)]
    public float frontViewAngle;

    public float leftViewTime;
    public float centerViewTime;
    public float rightViewTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(cameraTransform.rotation.y < transform.rotation.y - frontViewAngle)
        {
            leftViewTime += Time.deltaTime;
        }
        else if(cameraTransform.rotation.y > transform.rotation.y + frontViewAngle)
        {
            rightViewTime += Time.deltaTime;
        }
        else
        {
            centerViewTime += Time.deltaTime;
        }

    }
}
