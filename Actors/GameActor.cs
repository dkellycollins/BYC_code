using System;
using CC.Debug;
using UnityEngine;

public class GameActor : MonoBehaviour
{
    public float MoveSpeed = 1.0f;

    private CharacterController _controller;

    public event Action Moved = delegate { }; 

    public virtual void Move(Vector3 targetDirection)
    {
        _controller.Move(targetDirection*MoveSpeed*Time.deltaTime);
        Moved();
    }

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        Require.That(_controller, "_controller").IsNotNull();
    }
}
