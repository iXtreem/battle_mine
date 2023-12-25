public abstract class TouchedWallState : MovementState
{
    public TouchedWallState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character){ }

    public override void Enter()
    {
        base.Enter();

        View.StartWalled();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopWalled();
    }

}