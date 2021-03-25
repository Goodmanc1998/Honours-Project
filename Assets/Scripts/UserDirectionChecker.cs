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

        if (cameraTransform.eulerAngles.y < transform.parent.eulerAngles.y - frontViewAngle)
        {
            leftViewTime += Time.deltaTime;
        }
        else if(cameraTransform.eulerAngles.y > transform.parent.eulerAngles.y + frontViewAngle)
        {
            rightViewTime += Time.deltaTime;
        }
        else
        {
            centerViewTime += Time.deltaTime;
        }

    }

    private void UpdateScore(GameEvents state)
    {
        if (state != GameEvents.GAMEEVENT_PLAYERFINISH)
            return;

        Vector3 LookingTimes = new Vector3(Mathf.RoundToInt(leftViewTime), Mathf.RoundToInt(centerViewTime), Mathf.RoundToInt(rightViewTime));

        GameManager.Instance.UpdatePlayerDirection(LookingTimes);
    }
}
