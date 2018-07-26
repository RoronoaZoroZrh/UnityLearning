using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraScript))]
public class ExtendInspector : Editor
{
    public override void OnInspectorGUI()
    {
        CameraScript vTar = target as CameraScript;
        vTar.CameraRect = EditorGUILayout.RectField("Location", vTar.CameraRect);
        vTar.CameraTexture = EditorGUILayout.ObjectField("Add Texture", vTar.CameraTexture, typeof(Texture), true) as Texture;
    }
}