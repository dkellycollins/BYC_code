using UnityEngine;

namespace CC.Debug
{
    /// <summary>
    /// Used to enter in commands via the keyboard.
    /// </summary>
    public class DebugConsole : MonoBehaviour
    {
        private string _command = null;

        private void Awake()
        {
            enabled = UnityEngine.Debug.isDebugBuild;

            if (enabled)
            {
                UnityEngine.Debug.Log("Debug Console Enabled");
            }
        }

        private void Update()
        {
            foreach(var c in Input.inputString)
            {
                if (c == ';')
                {
                    if (_command == null)
                    {
                        _command = string.Empty;
                    }
                    else
                    {
                        CommandProcessor.Process(_command);
                        _command = null;
                    }
                }
                else if (c == '\b' && !string.IsNullOrEmpty(_command))
                {
                    _command = _command.Remove(_command.Length - 1);
                }
                else
                {
                    _command += c;
                }
            }

            if (Input.inputString.Length > 0)
            {
                UnityEngine.Debug.Log(_command);
            }
        }
    }
}
