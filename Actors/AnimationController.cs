using CC.Debug;
using UnityEngine;

public class AnimationController : MonoBehaviour 
{
    private enum PlayerState
    {
        IDLE,
        WALKING
    }

    public AnimationClip IdleAnimation;
    public AnimationClip WalkingAnimation;

    private StateMachine<PlayerState> _stateMachine;
    private CharacterController _player;
    private Animation _animation;

    private void Awake()
    {
        _stateMachine = new StateMachine<PlayerState>();
        _player = GetComponent<CharacterController>();
        _animation = GetComponentInChildren<Animation>();

        Require.That(_player, "_player").IsNotNull();
        Require.That(_animation, "_animation").IsNotNull();

        initStateHandlers();
    }

    private void initStateHandlers()
    {
        _stateMachine.AddTransitionHanlder(PlayerState.IDLE, PlayerState.IDLE, OnIdle);
        _stateMachine.AddTransitionHanlder(PlayerState.WALKING, PlayerState.WALKING, OnWalking);
    }

    private void Update()
    {
        if (_player.velocity.normalized.magnitude > 1)
        {
            _stateMachine.Advance(PlayerState.WALKING);
        }
        else
        {
            _stateMachine.Advance(PlayerState.IDLE);
        }
    }

    private void OnIdle()
    {
        _animation.CrossFade(IdleAnimation.name);
    }

    private void OnWalking()
    {
        _animation.CrossFade(WalkingAnimation.name);
    }
}
