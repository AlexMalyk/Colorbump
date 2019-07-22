using UnityEngine;
using Events;

public class UIControl : MonoBehaviour
{
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject restartUI;
    [SerializeField] private GameObject firstTouchUI;

    #region Enable / Disable
    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, OnGameSetup);
        EventManager.StartListening(EventId.Event_GameStart, OnGameStart);
        EventManager.StartListening(EventId.Event_GameFail, OnGameFail);
        EventManager.StartListening(EventId.Event_GameFinish, OnGameFinish);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, OnGameSetup);
        EventManager.StopListening(EventId.Event_GameStart, OnGameStart);
        EventManager.StopListening(EventId.Event_GameFail, OnGameFail);
        EventManager.StopListening(EventId.Event_GameFinish, OnGameFinish);
    }
    #endregion

    public void OpenMenu()
    {
        SetGameUI(false);
    }

    private void OnGameSetup()
    {
        SetGameUI(true);
    }

    private void OnGameStart()
    {
        firstTouchUI.SetActive(false);
    }

    private void OnGameFinish()
    {
        restartUI.SetActive(true);
    }

    private void OnGameFail()
    {
        restartUI.SetActive(true);
    }

    private void SetGameUI(bool value)
    {
        menuUI.SetActive(!value);

        restartUI.SetActive(false);

        gameUI.SetActive(value);
        firstTouchUI.SetActive(value);
    }
}