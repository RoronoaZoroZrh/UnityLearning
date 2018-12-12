/* 
 *  @author zhangronghuan
 *  @date   2018-11-26 11:43:18
 *  @brief  Game视图镜头自动与Scene视图镜头同步
 */
using UnityEditor;
using UnityEngine;

internal class AutoAlighWithView
{
    [MenuItem("ZRHPersonal/AutoAlighWithView", false, 0)]
    private static void Excute()
    {
        EditorApplication.update += () =>
        {
            Camera.main.transform.position = SceneView.lastActiveSceneView.camera.transform.position;
            Camera.main.transform.rotation = SceneView.lastActiveSceneView.camera.transform.rotation;
        };
    }
}