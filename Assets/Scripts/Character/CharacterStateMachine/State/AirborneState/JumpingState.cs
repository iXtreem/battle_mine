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

        Vector2 JumpDirection;

        if (_wallChecker.IsTouchesWall)
        {
            JumpDirection = new Vector2(_wallChecker._isTouchesLeftWall ? 5 : -5, _config.JumpingStateConfig.StartYVelocity);
            Debug.Log(JumpDirection);
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

        /*if (_wallChecker.IsTouchesWall)
        {
            StateSwitcher.SwitchState<SlideOnWallState>();
        }*/

        if (Rigidbody.velocity.y <= 0)
            StateSwitcher.SwitchState<FallingState>();
    }
}