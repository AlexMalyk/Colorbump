using UnityEngine;
using Events;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform cameraTransfrom;
    [SerializeField] private MeshRenderer meshRenderer;

    [Header("Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float wallDistance;
    [SerializeField] private float minCameraDistance;
    [SerializeField] private float maxDistance;

    private bool isMoveAllowed = false;

    private Vector2 lastMousePosition;
    private Vector3 startPosition;

    private void Start()
    {
        Input.multiTouchEnabled = false;
        startPosition = transform.position;
    }

    #region Enable/Disable
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
    #endregion

    #region Updates
    void Update()
    {
        if (!isMoveAllowed)
            return;

        if (Input.GetMouseButton(0))
        {
            Vector2 currentMousePosition = Input.mousePosition;

            if (lastMousePosition == Vector2.zero)
                lastMousePosition = currentMousePosition;

            Vector2 deltaPosition = currentMousePosition - lastMousePosition;
            lastMousePosition = currentMousePosition;

            Vector3 force = new Vector3(deltaPosition.x, 0, deltaPosition.y) * speed;
            rigidbody.AddForce(force);
        }
        else
            lastMousePosition = Vector2.zero;
    }

    private void LateUpdate()
    {
        Vector3 position = transform.position;

        position.x = WallDistanceCheck(position.x);
        position.z = CameraDistanceCheck(position.z);
        position.z = MaxDistanceCheck(position.z);

        transform.position = position;
    }
    #endregion

    #region Position Checks
    private float WallDistanceCheck(float x)
    {
        if (x < -wallDistance)
            return -wallDistance;

        if (x > wallDistance)
            return wallDistance;

        return x;
    }

    private float CameraDistanceCheck(float z)
    {
        float minZposition = cameraTransfrom.position.z + minCameraDistance;

        if (z < minZposition)
            return minZposition;

        return z;
    }

    private float MaxDistanceCheck(float z)
    {
        if (z > maxDistance)
            return maxDistance;

        return z;
    }
    #endregion

    #region Collision Listeners
    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        if (tag == TagManager.badTag)
        {
            meshRenderer.enabled = false;
            isMoveAllowed = false;

            EventManager.TriggerEvent(EventId.Event_GameFail);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        string tag = other.tag;

        if (tag == TagManager.finishTag)
        {
            isMoveAllowed = false;

            EventManager.TriggerEvent(EventId.Event_GameFinish);
        }
    }
    #endregion

    #region Event Listeners
    private void OnGameSetup()
    {
        transform.position = startPosition;
        rigidbody.velocity = Vector3.zero;
        lastMousePosition = Vector2.zero;

        meshRenderer.enabled = true;
        isMoveAllowed = false;
    }

    private void OnGameStart()
    {
        isMoveAllowed = true;
    }
    #endregion
}