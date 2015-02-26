using System;
using CC.Debug;
using UnityEngine;

public class GameActor : BaseBehaviour
{
    public float MoveSpeed = 1.0f;
    public float TurnSpeed = 1.0f;
    public float Gravity = 10.0f;

    private CharacterController _controller;

    public virtual void Move(Vector3 targetDirection)
    {
        //Apply gravity if the character is in the air.
        if (!_controller.isGrounded)
        {
            targetDirection.y -= Gravity;
        }

        //Move the controller
        targetDirection.x *= MoveSpeed;
        targetDirection.z *= MoveSpeed;

        _controller.Move(targetDirection * Time.deltaTime);
    }

    protected virtual void Awake()
    {
        _controller = GetComponent<CharacterController>();

        Require.That(_controller, "_controller").IsNotNull();
    }
}
