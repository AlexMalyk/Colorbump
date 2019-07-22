using UnityEngine;

public class Figure : MonoBehaviour
{
    public FigureData figureData;

    [Header("Components")]
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private MeshRenderer meshRenderer;

    [Header("Materials")]
    [SerializeField] private Material materialBad;
    [SerializeField] private Material materialGood;

    public FigureType FigureType => figureData.figureType;

    public void CreateFigure(FigureData data, Transform parent)
    {
        this.transform.parent = parent;

        SetData(data);
    }

    public void SetData(FigureData data)
    {
        SetPosition(data.position);
        SetRotation(data.rotation);
        SetTag(data.figureStatus);

        figureData = data;
    }

    public void ResetRigidbody()
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    private void SetPosition(Vector3 position)
    {
        transform.localPosition = position;
    }

    private void SetRotation(Quaternion rotation)
    {
        transform.localRotation = rotation;
    }

    private void SetTag(FigureStatus status)
    {
        if (status == FigureStatus.Bad)
        {
            tag = TagManager.badTag;
            meshRenderer.material = materialBad;
        }
        else
        {
            tag = TagManager.goodTag;
            meshRenderer.material = materialGood;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == TagManager.bottomTag)
        {
            this.gameObject.SetActive(false);
        }
    }

    #region Editor Methods
#if UNITY_EDITOR
    public void UpdateView()
    {
        SetTag(figureData.figureStatus);
    }
#endif
    #endregion
}

[System.Serializable]
public class FigureData
{
    public FigureType figureType;
    public FigureStatus figureStatus;
    public Vector3 position;
    public Quaternion rotation;
}
public enum FigureType
{
    Cube, Cube_x2, Rectangle_Horizontal, Rectangle_Vertical
}

public enum FigureStatus
{
    Good, Bad
}