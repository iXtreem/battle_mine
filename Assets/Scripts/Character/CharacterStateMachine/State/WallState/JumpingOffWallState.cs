using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class JumpingOffWallState : AirborneState
{
    private readonly AirborneStateConfig _config;
    private readonly WallChecker _wallChecker;
    public JumpingOffWallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _config = character.Config.AirborneStateConfig;
        _wallChecker = character.WallChecker;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartJumping();

        Data.Speed = _config.Speed;
        Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, _config.JumpingStateConfig.StartYVelocity);
    }

    public override void Exit()
    {
        base.Exit();

        View.StopJumping();
    }

    public override void Update()
    {
        base.Update();

        if (Rigidbody.velocity.y <= 0) 
        {
            if (_wallChecker.IsTouchesWall)
            {
                StateSwitcher.SwitchState<SlideOnWallState>();
            }
            StateSwitcher.SwitchState<FallingState>();
        }
    }

    protected override float ReadHorizontalInput() => _wallChecker._isTouchesLeftWall ? 1 : -1;
}