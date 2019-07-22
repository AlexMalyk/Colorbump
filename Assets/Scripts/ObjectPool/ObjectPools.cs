using Events;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPools : MonoBehaviour
{
    private Dictionary<FigureType, ObjectPool> objectPools;

    private void Start()
    {
        ObjectPool[] pools = GetComponents<ObjectPool>();

        objectPools = new Dictionary<FigureType, ObjectPool>();

        for (int i = 0; i < pools.Length; i++)
        {
            objectPools.Add(pools[i].GetFigure().figureData.figureType, pools[i]);
        }
        
    }

    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_StageCreated, OnStageCreated);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_StageCreated, OnStageCreated);
    }

    private void OnStageCreated()
    {
        foreach (var pool in objectPools)
        {
            pool.Value.HideNotUsedFigures();
        }
    }

    public Figure GetFigureByType(FigureType figureType)
    {
        objectPools.TryGetValue(figureType, out ObjectPool pool);

        return pool.GetFigure();
    }
}