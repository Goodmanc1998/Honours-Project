using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public enum GameEvents
{
    GAMEEVENT_GAMESTART,
    GAMEEVENT_PLAYERFINISH,
    GAMEEVENT_UPLOADSTART,
    GAMEEVENT_UPLOADFINISH
}

public class GameManager : MonoBehaviour
{
    //Player
    private GameObject player;
    public SceneChange scene;


    public Vector3 lookingDirections;

    public SaveData currScore = new SaveData();

    List<SaveData> currSaves = new List<SaveData>();

    public Text dirText;




    //Hazard Types
    public enum Hazards
    {
        Developing,
        Possible,
        Area
    }

    // GAme STATES

    public delegate void GameEvent(GameEvents gameEvent);
    public static GameEvent onGameEvent;

    // Singleton get instance 
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }


    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        player = GameObject.FindGameObjectWithTag("Player");

        scene = gameObject.GetComponent<SceneChange>();

        currSaves = SavingToXML.LoadData(scene.GetSceneName());

        GameManager.onGameEvent += Event;

        //dirText.text = SavingToXML.getDirectory();
    }



    public void UpdatePlayerScore(Hazards currHazard, int newAmount)
    {
        switch(currHazard)
        {
            case Hazards.Developing:
                currScore.increaseDev(newAmount);
                break;
            case Hazards.Possible:
                currScore.increasePos(newAmount);
                break;
            case Hazards.Area:
                currScore.increaseArea(newAmount);
                break;
            default:
                return;
        }
    }

    public void UpdatePlayerDirection(Vector3 dir)
    {
        currScore.setLooking(dir);

        onGameEvent(GameEvents.GAMEEVENT_UPLOADSTART);
    }

    void Event(GameEvents gameEvent)
    {
        Debug.Log(gameEvent.ToString());

        if (gameEvent == GameEvents.GAMEEVENT_UPLOADSTART)
        {
            SavingToXML.SaveToXML(scene.GetSceneName(), currScore, currSaves);
        }

        if (gameEvent == GameEvents.GAMEEVENT_UPLOADFINISH)
        {
            if (Application.platform == RuntimePlatform.Android)
                scene.ChangeScene();
        }

    }



    
}
