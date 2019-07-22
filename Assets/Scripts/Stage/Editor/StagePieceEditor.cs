using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StagePiece))]
public class StagePieceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GUI.enabled = !Application.isPlaying;

        StagePiece myScript = (StagePiece)target;

        if (GUILayout.Button("SetDataFromScene"))
            myScript.SetDataFromScene();
    }
}