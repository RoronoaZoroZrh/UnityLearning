using UnityEditor;
using UnityEngine;

namespace UNetStuty
{
    public class UNetEditor
    {
        [MenuItem("UnityStudy/UNetStudy/SpawnGameObject")]
        private static void SpawnGameObject()
        {
            GameObject transmitter = GameObject.Find("Transmitter(Clone)");
            if (transmitter != null)
            {
                transmitter.GetComponent<SpawnObjectComponent>().StartTest();
            }
        }
    }
}