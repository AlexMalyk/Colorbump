using UnityEngine;
using Events;

public class StageControl : MonoBehaviour
{
    [SerializeField] private GameObject stage;

    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, OnGameSetup);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, OnGameSetup);
    }

    void OnGameSetup()
    {
        stage.SetActive(true);
    }
}