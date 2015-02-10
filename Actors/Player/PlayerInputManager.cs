using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : Singleton<PlayerInputManager>, IInputManager
{
    public ActorCommand[] GetCommands()
    {
        var commands = new List<ActorCommand>();

        //Movement
        var moveVector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        if (moveVector != Vector2.zero)
        {
            commands.Add(new PlayerMoveCommand(moveVector, Camera.main.transform));
        }

        return commands.ToArray();
    }
}
