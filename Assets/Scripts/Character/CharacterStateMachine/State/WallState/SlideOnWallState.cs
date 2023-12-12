using UnityEngine;

public class SlideOnWallState : TouchedWallState
{
    private readonly GroundChecker _groundChecker;
    private readonly WallChecker _wallChecker;
    private readonly SlideWallStateConfig _config;

    public SlideOnWallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundChecker = character.GroundChecker;
        _wallChecker = character.WallChecker;
        _config = character.Config.SlideWallStateConfig;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartSlideOnWall();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopSlideOnWall();
    }

    public override void Update()
    {
        base.Update();

        Rigidbody.velocity = GetSlideWallVelocity();

        if (_groundChecker.IsTouches)
        {
            StateSwitcher.SwitchState<IdlingState>();
        }

        if (_wallChecker.IsTouchesWall)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StateSwitcher.SwitchState<JumpingOffWallState>();
            }
        }
        else if (Rigidbody.velocity.y <= 0)
        {
            StateSwitcher.SwitchState<FallingState>();
        }
    }

    private Vector2 GetSlideWallVelocity()
    {
        return new Vector2(Rigidbody.velocity.x, _config.Speed);
    }
}