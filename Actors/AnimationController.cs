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

    //private StateMachine<PlayerState> _stateMachine;
    private GameActor _player;
    private Animation _animation;

    private void Awake()
    {
        //_stateMachine = new StateMachine<PlayerState>();
        _player = GetComponent<GameActor>();
        _animation = GetComponentInChildren<Animation>();

        Require.That(_player, "_player").IsNotNull();
        Require.That(_animation, "_animation").IsNotNull();

        //_stateMachine.AddStateHandler(PlayerState.IDLE, OnIdle);
        //_stateMachine.AddStateHandler(PlayerState.WALKING, OnWalking);
    }

    private void FixedUpdate()
    {
        //_stateMachine.Update();
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
