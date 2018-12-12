using System;
using UnityEngine;
using UnityEngine.Networking;

namespace UNetStuty
{
    public class LogComponent : NetworkBehaviour
    {
        protected enum Level
        {
            LevelDebug,
            LevelInfo,
            LevelWarning,
            LevelError,
        }

        [SerializeField]
        private Level _level = Level.LevelInfo;

        private void Start()
        {
            UNetStudyLog.Initialize(this);
        }

        [Client]
        public void SyncLevel()
        {
            CmdSyncLevel(_level);
        }

        [Command]
        private void CmdSyncLevel(Level level)
        {
            _level = level;
        }

        public void LogDebug(String message)
        {
            if (_level <= Level.LevelDebug)
            {
                Log(message, Level.LevelDebug);
            }
        }

        public void LogInfo(String message)
        {
            if (_level <= Level.LevelInfo)
            {
                Log(message, Level.LevelInfo);
            }
        }

        public void LogWarning(String message)
        {
            if (_level <= Level.LevelWarning)
            {
                Log(message, Level.LevelWarning);
            }
        }

        public void LogError(String message)
        {
            if (_level <= Level.LevelError)
            {
                Log(message, Level.LevelError);
            }
        }

        private void Log(String message, Level level)
        {
            if (isLocalPlayer)
            {
                LogImpl(message, level);
            }
            else
            {
                RpcLog(message, level);
            }
        }

        [ClientRpc]
        private void RpcLog(String message, Level level)
        {
            LogImpl(String.Format("Server {0}", message), level);
        }

        private void LogImpl(String message, Level level)
        {
            switch (level)
            {
                case Level.LevelDebug:
                case Level.LevelInfo:
                    Debug.Log(message);
                    break;
                case Level.LevelWarning:
                    Debug.LogWarning(message);
                    break;
                case Level.LevelError:
                    Debug.LogError(message);
                    break;
            }
        }
    }
}