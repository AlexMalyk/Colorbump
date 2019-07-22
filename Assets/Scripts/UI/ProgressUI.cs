using Events;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Transform playerTransfrom;

    private void OnEnable()
    {
        EventManager.StartListening(EventId.Event_GameSetup, OnGameSetup);
    }

    private void OnDisable()
    {
        EventManager.StopListening(EventId.Event_GameSetup, OnGameSetup);
    }

    private void Update()
    {
        float zPosition = playerTransfrom.position.z;

        if (zPosition > 0 && zPosition <= 100)
            fillImage.fillAmount = zPosition / 100;
    }

    void OnGameSetup()
    {
        fillImage.fillAmount = 0;
    }
}