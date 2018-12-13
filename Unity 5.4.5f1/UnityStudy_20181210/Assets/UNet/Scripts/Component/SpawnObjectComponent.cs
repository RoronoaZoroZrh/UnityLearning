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
            if (isLocalPlayer)
            {
                ClientScene.RegisterPrefab(_prefabGameObject);
            }
        }

        public void StartTest()
        {
            CmdSpawn();
        }

        [Command]
        public void CmdSpawn()
        {
            try
            {
                NetworkServer.Spawn((GameObject)Instantiate(_prefabGameObject, Vector3.zero, Quaternion.identity));
            }
            catch (System.Exception exception)
            {
                UNetStudyLog.Exception(exception);
            }
        }
    }
}