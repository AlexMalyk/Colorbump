using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    [SerializeField] GameObject particleSystem;

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

    private void OnGameSetup()
    {
        particleSystem.SetActive(true);
    }

    private void OnGameStart()
    {
        particleSystem.SetActive(false);

    }
}