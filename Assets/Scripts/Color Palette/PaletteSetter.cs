using Events;
using System.Collections.Generic;
using UnityEngine;

public class PaletteSetter : MonoBehaviour
{
    [SerializeField] private List<Palette> palettes;

    [Header("Materials")]
    [SerializeField] private Material floorMaterial;
    [SerializeField] private Material goodMaterial;
    [SerializeField] private Material badMaterial;

    private int lastPaletteIndex = -1;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;     
    }

    #region Enable/Disable 
    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, OnGameSetup);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, OnGameSetup);
    }
    #endregion

    public void SetRandomPalette()
    {
        int i = Random.Range(0, palettes.Count);

        if (i == lastPaletteIndex)
            SetRandomPalette();
        else
        {
            SetMaterials(palettes[i]);
            lastPaletteIndex = i;
        }
    }

    private void OnGameSetup()
    {
        SetRandomPalette();
    }

    private void SetMaterials(Palette palette)
    {
        floorMaterial.color = palette.FloorColor;
        goodMaterial.color = palette.GoodColor;
        badMaterial.color = palette.BadColor;

        mainCamera.backgroundColor = palette.BackgroundColor;
    }
}