using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDirectionChecker : MonoBehaviour
{

    public Transform cameraTransform;

    [Range(0, 360)]
    public float frontViewAngle;

    public float leftViewTime;
    public float centerViewTime;
    public float rightViewTime;

    float leftAngle;
    float rightAngle;
    float frontAngle;
    float rearAngle;

    Vector3 cameraRot;
    Vector3 carDir;


    float camAngle;

    private void Awake()
    {
        GameManager.onGameEvent += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.onGameEvent -= UpdateScore;

    }

    // Update is called once per frame
    void Update()
    {
        float angle = Vector3.Angle(transform.forward, cameraTransform.forward);

        float diff =  transform.localRotation.y - cameraTransform.localRotation.y;





        if (angle <= frontViewAngle)
        {
            centerViewTime += Time.deltaTime;
        }
        else if(angle > frontAngle)
        {
            if(diff < 0)
            {
                rightViewTime += Time.deltaTime;
            }
            else if (diff > 0)
            {
                leftViewTime += Time.deltaTime;
            }
        }



        Debug.Log("Angle : " + diff);

        
        

        

    }

    private void UpdateScore(GameEvents state)
    {
        if (state != GameEvents.GAMEEVENT_PLAYERFINISH)
            return;

        Vector3 LookingTimes = new Vector3(Mathf.RoundToInt(leftViewTime), Mathf.RoundToInt(centerViewTime), Mathf.RoundToInt(rightViewTime));

        GameManager.Instance.UpdatePlayerDirection(LookingTimes);
    }
}
