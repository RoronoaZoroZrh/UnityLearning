using UnityEngine;
using UnityEngine.Networking;

namespace UNetStuty
{
    public class SpawnObjectComponent : NetworkBehaviour
    {
        private GameObject _prefabGameObject;

        private void Start()
        {
            _prefabGameObject = Resources.Load<GameObject>("Prefabs/Cube");
            //_prefabGameObject.AddComponent<NetworkIdentity>();
            //_prefabGameObject.AddComponent<NetworkTransform>();
            if (isLocalPlayer)
            {
                ClientScene.RegisterPrefab(_prefabGameObject);
            }
        }

        private void OnDestroy()
        {
            DestroyImmediate(_prefabGameObject.GetComponent<NetworkIdentity>());
            DestroyImmediate(_prefabGameObject.GetComponent<NetworkTransform>());
        }

        public void StartTest()
        {
            if (isLocalPlayer)
            {
                CmdSpawn();
            }
            else
            {
                try
                {
                    GameObject spawnGameObject = (GameObject)Instantiate(_prefabGameObject, Vector3.zero, Quaternion.identity);
                    NetworkServer.Spawn(spawnGameObject);
                }
                catch (System.Exception exception)
                {
                    UNetStudyLog.Exception(exception);
                }
            }
        }

        [Command]
        public void CmdSpawn()
        {
            try
            {
                GameObject spawnGameObject = (GameObject)Instantiate(_prefabGameObject, Vector3.zero, Quaternion.identity);
                NetworkServer.Spawn(spawnGameObject);
            }
            catch (System.Exception exception)
            {
                UNetStudyLog.Exception(exception);
            }
        }
    }
}