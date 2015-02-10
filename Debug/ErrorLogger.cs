using UnityEngine;

namespace CC.Debug
{
    public class ErrorLogger : ScriptableObject
    {
        private void OnEnable() 
        {
            UnityEngine.Debug.Log("Error Logger enabled.");
            //Application.RegisterLogCallback(HandleLog);
        }

        private void OnDisable()
        {
            UnityEngine.Debug.Log("Error Logger disabled.");
            //Application.RegisterLogCallback(null);
        }

        private void HandleLog(string log, string stackTrace, LogType type) 
        {
            UnityEngine.Debug.Log("Log received.");
        }
    }
}
