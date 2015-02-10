
using UnityEngine;

namespace CC.Debug
{
    public class CommandProcessor
    {
        private static ErrorLogger logger;

        public static void Process(string cmd)
        {
            string[] args = cmd.Split(' ');
            switch (args[0].ToLower())
            {
                case "scripttest":
                    ScriptTest(args);
                    break;
            }
        }

        private static void ScriptTest(string[] args)
        {
            logger = ScriptableObject.CreateInstance<ErrorLogger>();
        }
    }
}
