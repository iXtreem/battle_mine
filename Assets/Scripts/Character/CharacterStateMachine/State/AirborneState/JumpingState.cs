public class JumpingState : AirborneState
{
    private readonly AirborneStateConfig _config;

    public JumpingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.AirborneStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartJumping();

        Data.Speed = _config.Speed;
        Rigidbody.velocity = new UnityEngine.Vector2(Rigidbody.velocity.x, _config.JumpingStateConfig.StartYVelocity); 
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
            StateSwitcher.SwitchState<FallingState>();
    }
}