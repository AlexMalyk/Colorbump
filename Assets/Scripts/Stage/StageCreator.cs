using Events;
using System.Collections.Generic;
using UnityEngine;

public class StageCreator : MonoBehaviour
{
    [SerializeField] private List<StagePiece> stagePieces;
    [SerializeField] private List<StagePieceData> stagePiecesData;

    #region Enable / Disable
    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, CreateStages);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, CreateStages);
    }
    #endregion

    public void CreateStages()
    {
        for (int i = 0; i < stagePieces.Count; i++)
            stagePieces[i].CreateStagePiece(stagePiecesData[Random.Range(0, stagePiecesData.Count)]);

        EventManager.TriggerEvent(EventId.Event_StageCreated);
    }
}