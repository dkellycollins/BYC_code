using System.Collections;
using UnityEngine;

/// <summary>
/// Handles translating player input to actor movement
/// </summary>
public class PlayerMoveCommand : ActorCommand
{
    private readonly Vector2 _inputVector;
    private readonly Transform _cameraTransform;

    public PlayerMoveCommand(Vector2 inputVector, Transform cameraTransform)
    {
        _inputVector = inputVector;
        _cameraTransform = cameraTransform;
    }

    public override IEnumerator Execute(GameActor actor)
    {
        // Forward vector relative to the camera along the x-z plane
        var forward = _cameraTransform.TransformDirection(Vector3.forward);
        forward.y = 0;
        forward = forward.normalized;

        // Right vector relative to the camera
        var right = new Vector3(forward.z, 0, -forward.x);

        var moveVector = _inputVector.x * right + _inputVector.y * forward;
        actor.Move(moveVector);
        return null;
    }
}