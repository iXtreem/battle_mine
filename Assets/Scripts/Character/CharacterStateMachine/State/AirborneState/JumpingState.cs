using UnityEngine;

public class JumpingState : AirborneState
{
    private readonly AirborneStateConfig _config;
    private readonly WallChecker _wallChecker;
    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.AirborneStateConfig;
        _wallChecker = character.WallChecker;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartJumping();

        Data.Speed = _config.Speed;
        Data.TimeLastJump = 0;

        Vector2 JumpDirection;

        if (_wallChecker.IsTouchesWall)
        {
            JumpDirection = new Vector2(_wallChecker._isTouchesLeftWall ? 5 : -5, _config.JumpingStateConfig.StartYVelocity);
        }
        else
        {
            JumpDirection = new Vector2(Rigidbody.velocity.x, _config.JumpingStateConfig.StartYVelocity);
        }

        Rigidbody.velocity = JumpDirection; 
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        if (_wallChecker.IsTouchesWall && CanSlideOnWall())
        {
            StateSwitcher.SwitchState<SlideOnWallState>();
        }

        if (Rigidbody.velocity.y <= 0)
            StateSwitcher.SwitchState<FallingState>();
    }

    private bool CanSlideOnWall()
    {
        return Data.TimeLastJump > _config.JumpingStateConfig.MinDirectionJumping;
    }
}