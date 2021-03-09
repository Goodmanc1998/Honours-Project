using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinishTrigger : MonoBehaviour
{

    private GameManager gameMgr;

    private void Awake()
    {
        if (gameMgr == null)
        {
            gameMgr = GameManager.Instance;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.onGameEvent(GameEvents.GAMEEVENT_PLAYERFINISH);
        }
    }
}
