using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void SetupGame()
    {
        EventManager.TriggerEvent(EventId.Event_GameSetup);
    }

    public void StartGame()
    {
        EventManager.TriggerEvent(EventId.Event_GameStart);
    }
}