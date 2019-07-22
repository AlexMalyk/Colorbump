using Events;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    [SerializeField] GameObject particleSystem;

    #region Enable / Disable
    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, OnGameSetup);
        EventManager.StartListening(EventId.Event_GameStart, OnGameStart);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, OnGameSetup);
        EventManager.StopListening(EventId.Event_GameStart, OnGameStart);
    }
    #endregion

    private void OnGameSetup()
    {
        particleSystem.SetActive(true);
    }

    private void OnGameStart()
    {
        particleSystem.SetActive(false);
    }
}