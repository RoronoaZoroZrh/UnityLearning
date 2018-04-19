using UnityEditor;
using UnityEngine;

public class PlugInWindow : EditorWindow
{
    private string m_sName = "";

    [MenuItem("Plug-in/Plug-in_20180418")]
    static void ShowPlugInWindow()
    {
        EditorWindow.GetWindow<PlugInWindow>("AB查看器", typeof(PlugInWindow));
    }

    void OnGUI()
    {
        //Label
        GUILayout.Label("AB信息", EditorStyles.whiteLargeLabel);

        //TextField
        Rect vRect = EditorGUILayout.GetControlRect();
        m_sName = EditorGUI.TextField(vRect, "AB路径", m_sName, EditorStyles.textField);

        //Drag Event
        if (vRect.Contains(Event.current.mousePosition))
        {
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
            if (Event.current.type == EventType.DragPerform)
            {
                m_sName = DragAndDrop.paths[0];
            }
        }

        //Button
        if (GUILayout.Button("保存AB"))
        {
            foreach (Object vItr in Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets))
            {
                string sPath = AssetDatabase.GetAssetPath(vItr);
                AssetImporter vImporter = AssetImporter.GetAtPath(sPath);
                vImporter.assetBundleName = System.IO.Path.GetFileNameWithoutExtension(sPath) + "_T";
            }
            BuildPipeline.BuildAssetBundles("Assets/AssetBundles/", BuildAssetBundleOptions.None, BuildTarget.Android);
        }

        //Button
        if (GUILayout.Button("读取AB"))
        {
            System.IO.DirectoryInfo vDirInfo = new System.IO.DirectoryInfo("Assets/AssetBundles/");
            foreach (System.IO.FileInfo vFile in vDirInfo.GetFiles())
            {
                string sExtension = System.IO.Path.GetExtension(vFile.FullName);
                if (string.IsNullOrEmpty(sExtension))
                {
                    AssetBundle vBundle = AssetBundle.LoadFromFile(vFile.FullName);
                    if (vBundle != null && !string.IsNullOrEmpty(vBundle.name))
                    {
                        Debug.Log(vBundle.name);
                        Instantiate(vBundle.LoadAsset(vBundle.name.Substring(0, vBundle.name.Length - 2)));
                        vBundle.Unload(false);
                    }
                }
            }
        }
    }
}