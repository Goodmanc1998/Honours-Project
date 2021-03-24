using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousArea : Hazard
{

    public float checkTime = 0f;
    public float maxCheckTime = 5f;
    public bool looking = false;

    private void Awake()
    {
        currHazard = GameManager.Hazards.Area;

        GameManager.onGameEvent += UpdateScore;
    }


    private void OnDisable()
    {
        GameManager.onGameEvent -= UpdateScore;

    }

    // Update is called once per frame
    void Update()
    {
        if(looking && checkTime <= maxCheckTime)
        {
            checkTime += Time.deltaTime * 2;
        }
    }

    private void UpdateScore(GameEvents state)
    {
        if (state != GameEvents.GAMEEVENT_PLAYERFINISH)
            return;

        GameManager.Instance.UpdatePlayerScore(currHazard, Mathf.RoundToInt(checkTime));
    }

    public void StartLookingArea()
    {
        looking = true;
    }

    public void StopLookingArea()
    {
        looking = false;
    }
}
