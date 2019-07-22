using System;
using Events;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float maxDistance;

    private bool isMoveAllowed = false;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    #region Enable/Disable
    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, OnGameSetup);
        EventManager.StartListening(EventId.Event_GameStart, OnGameStart);
        EventManager.StartListening(EventId.Event_GameFail, OnGameFail);
    }

    private void OnGameFail()
    {
        isMoveAllowed = false;
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, OnGameSetup);
        EventManager.StopListening(EventId.Event_GameStart, OnGameStart);
        EventManager.StopListening(EventId.Event_GameFail, OnGameFail);
    }
    #endregion

    private void FixedUpdate()
    {
        Vector3 position = transform.position;

        if (isMoveAllowed)
            position += speed * Time.fixedDeltaTime * Vector3.forward;

        if (position.z > maxDistance)
            position.z = maxDistance;

        transform.position = position;
    }

    #region Event Listeners
    private void OnGameSetup()
    {
        transform.position = startPosition;
        isMoveAllowed = false;
    }

    private void OnGameStart()
    {
        isMoveAllowed = true;
    }
    #endregion
}