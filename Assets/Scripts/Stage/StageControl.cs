using UnityEngine;
using Events;

public class StageControl : MonoBehaviour
{
    [SerializeField] private GameObject stage;

    #region Enable / Disable
    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, OnGameSetup);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, OnGameSetup);
    }
    #endregion

    private void OnGameSetup()
    {
        stage.SetActive(true);
    }
}