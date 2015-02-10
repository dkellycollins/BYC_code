using CC.Debug;
using UnityEngine;
using System.Collections.Generic;

public class ScriptController : MonoBehaviour
{
    public string[] Commands;
    public bool Loop;

    private GameActor _actor;
    private ActorCommand[] _commands;
    private int _commandIndex;

    private void Awake()
    {
        _actor = GetComponent<GameActor>();

        Require.That(_actor, "_actor").IsNotNull();

        var commands = new List<ActorCommand>();
        foreach (var command in Commands)
        {
            commands.Add(string.IsNullOrEmpty(command) ? null : translateCommand(command));
        }
        _commands = commands.ToArray();
    }

    private void Update()
    {
        if (_commandIndex == _commands.Length)
        {
            if (Loop)
            {
                _commandIndex = 0;
            }
            else
            {
                return;    
            }
            
        }

        var command = _commands[_commandIndex++];
        if (command != null)
        {
            StartCoroutine(command.Execute(_actor));
        }
    }

    private ActorCommand translateCommand(string cmdText)
    {
        string[] args = cmdText.Split(' ');
        switch (args[0].ToLower())
        {
            case "move":
                return new MoveCommand(new Vector3(float.Parse(args[1]), float.Parse(args[2]), float.Parse(args[3])), float.Parse(args[4]));
            default:
                return null;
        }
    }
}
