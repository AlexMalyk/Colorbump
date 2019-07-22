using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagePiece : MonoBehaviour
{
    [SerializeField] private StagePieceData data;

    public ObjectPools objectPools;

    public void CreateStagePiece(StagePieceData stagePieceData)
    {
        data = stagePieceData;

        for (int i = 0; i < data.figuresData.Count; i++)
        {
            Figure figure = objectPools.GetFigureByType(data.figuresData[i].figureType);

            figure.transform.parent = transform;
            figure.SetData(data.figuresData[i]);
        }
    }

#if UNITY_EDITOR
    public void SetDataFromScene()
    {
        var figures = GetComponentsInChildren<Figure>();

        data.figuresData = new List<FigureData>();

        for (int i = 0; i < figures.Length; i++)
        {
            figures[i].figureData.position = figures[i].transform.localPosition;
            figures[i].figureData.rotation = figures[i].transform.localRotation;
            data.figuresData.Add(figures[i].figureData);
        }
    }
#endif
}