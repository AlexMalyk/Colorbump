using UnityEngine;

[CreateAssetMenu(fileName = "Color Palette", menuName ="Color Palette")]
public class Palette : ScriptableObject
{
    #region Fields
    [SerializeField] private Color goodColor = Color.white;
    [SerializeField] private Color badColor = Color.white;
    [SerializeField] private Color floorColor = Color.white;
    [SerializeField] private Color backgroundColor = Color.white;
    #endregion

    #region Properties
    public Color GoodColor { get => goodColor; }
    public Color BadColor { get => badColor; }
    public Color FloorColor { get => floorColor; }
    public Color BackgroundColor { get => backgroundColor; }
    #endregion
}