using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MoveCommand : ActorCommand
{
    public static readonly MoveCommand Forward = new MoveCommand(Vector3.forward);
    public static readonly MoveCommand Back = new MoveCommand(Vector3.back);
    public static readonly MoveCommand Left = new MoveCommand(Vector3.left);
    public static readonly MoveCommand Right = new MoveCommand(Vector3.right);

    private readonly Vector3 _moveVector;

    public MoveCommand(Vector3 moveVector)
    {
        _moveVector = moveVector;
    }

    public MoveCommand(Vector3 moveVector, float duration)
    {
        _moveVector = moveVector;
        Duration = duration;
    }

    public override IEnumerator Execute(GameActor actor)
    {
        for (float i = Duration; i > 0; i -= Time.deltaTime)
        {
            actor.Move(_moveVector);
            yield return null;
        }
    }
}
