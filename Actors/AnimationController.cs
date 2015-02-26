using CC.Debug;
using UnityEngine;

public enum PlayerState
{
    IDLE,
    WALKING
}

public class AnimationController : StateMachineBehaviour<PlayerState>
{
    public AnimationClip IdleAnimation;
    public AnimationClip WalkingAnimation;

    private CharacterController _player;
    private Animation _animation;
    private Vector3 _prevPosition;

    private void Awake()
    {
        _player = GetComponent<CharacterController>();
        _animation = GetComponentInChildren<Animation>();

        Require.That(_player, "_player").IsNotNull();
        Require.That(_animation, "_animation").IsNotNull();

        initStateHandlers();
    }

    private void initStateHandlers()
    {
        AddTransitionHanlder(PlayerState.IDLE, PlayerState.IDLE, OnIdle);
        AddTransitionHanlder(PlayerState.WALKING, PlayerState.WALKING, OnWalking);
    }

    protected override void Update()
    {
        if (_prevPosition != transform.position)
        {
            _prevPosition = transform.position;
            Advance(PlayerState.WALKING);
        }
        else
        {
            Advance(PlayerState.IDLE);
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
