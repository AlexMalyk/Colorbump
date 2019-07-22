using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Transform poolParent;
    [SerializeField] private GameObject prefab;

    [SerializeField] private  List<Figure> pool;

    [SerializeField] private int lastUsedIndex;
    [SerializeField] private int objectsCount;

    #region Enable / Disable
    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, ClearField);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, ClearField);
    }
    #endregion

    private void Start()
    {
        pool = poolParent.GetComponentsInChildren<Figure>().ToList();

        lastUsedIndex = -1;

        objectsCount = pool.Count;
    }

    public Figure GetFigure()
    {
        lastUsedIndex++;

        if (lastUsedIndex >= objectsCount)
            AddFigure();

        Figure figure = pool[lastUsedIndex];

        figure.ResetRigidbody();

        if (figure.gameObject.activeSelf == false)
            figure.gameObject.SetActive(true);

        return figure;
    }

    public void HideNotUsedFigures()
    {
        Transform figureTransform;

        for (int i = lastUsedIndex + 1; i < pool.Count; i++)
        {
            figureTransform = pool[i].transform;

            if (figureTransform.parent != poolParent)
                figureTransform.SetParent(poolParent, false);
            else
                break;
        }
    }

    private void ResetLastUsedIndexes()
    {
        lastUsedIndex = -1;
    }

    private void ClearField()
    {
        ResetLastUsedIndexes();
        HideNotUsedFigures();
    }

    private void AddFigure()
    {
        GameObject gObject = Instantiate(prefab, poolParent);

        pool.Add(gObject.GetComponent<Figure>());

        objectsCount++;
    }
}