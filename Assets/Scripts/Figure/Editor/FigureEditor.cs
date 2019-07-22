using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Figure))]
public class FigureEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GUI.enabled = !Application.isPlaying;

        Figure myScript = (Figure)target;

        if (GUILayout.Button("SetDataFromScene"))
            myScript.UpdateView();
    }
}