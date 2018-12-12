using System;
using UnityEngine;

namespace UNetStuty
{
    public class UNetStudyLog : MonoBehaviour
    {
        private static LogComponent _logComponent;

        public static void Initialize(LogComponent logComponent)
        {
            _logComponent = logComponent;
        }

        public static void Debug(String message)
        {
            if (_logComponent != null)
            {
                _logComponent.LogDebug(message);
            }
        }

        public static void Info(String message)
        {
            if (_logComponent != null)
            {
                _logComponent.LogInfo(message);
            }
        }

        public static void Warning(String message)
        {
            if (_logComponent != null)
            {
                _logComponent.LogWarning(message);
            }
        }

        public static void Error(String message)
        {
            if (_logComponent != null)
            {
                _logComponent.LogError(message);
            }
        }

        public static void Exception(Exception exception)
        {
            if (_logComponent != null)
            {
                _logComponent.LogError(String.Format("Exception Type={0} Message={1} StackTrace={2}", exception.GetType(), exception.Message, exception.StackTrace));
            }
        }
    }
}