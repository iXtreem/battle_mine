public class FallingState : AirborneState
{
    private readonly GroundChecker _groundChecker;
    private readonly WallChecker _wallChecker;

    public FallingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
        _groundChecker = character.GroundChecker;
        _wallChecker = character.WallChecker;
    }

    public override void Enter()
    {
        base.Enter();

        View.StartFalling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFalling();
    }

    public override void Update()
    {
        base.Update();

        if (_groundChecker.IsTouches)
        {
            if (IsHorizontalInputZero())
                StateSwitcher.SwitchState<IdlingState>();
            else
                StateSwitcher.SwitchState<RunningState>();
        }

        if (_wallChecker.IsTouchesWall) 
        {
            StateSwitcher.SwitchState<SlideOnWallState>();
        }
    }
}