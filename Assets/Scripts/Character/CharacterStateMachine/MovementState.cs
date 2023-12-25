using UnityEngine;

public abstract class MovementState : IState
{
    protected readonly IStateSwitcher StateSwitcher;
    protected readonly StateMachineData Data;

    private readonly Character _character;
    private const string Horizontal = "Horizontal";

    public MovementState(IStateSwitcher stateSwitcher, StateMachineData data, Character character)
    {
        StateSwitcher = stateSwitcher;
        Data = data;
        _character = character;
    }

    protected Rigidbody2D Rigidbody => _character.Rigidbody;
    protected CharacterView View => _character.View;

    private Quaternion TurnRight => new Quaternion(0, 0, 0, 0);
    private Quaternion TurnLeft => Quaternion.Euler(0, 180, 0);

    public virtual void Enter()
    {
        Debug.Log(GetType());

        View.StartMovement();
    }

    public virtual void Exit()
    {
        View.StopMovement();
    }

    public virtual void HandleInput()
    {
        Data.XInput = ReadHorizontalInput();
        Data.XVelocity = Data.XInput * Data.Speed;
    }

    public virtual void Update()
    {
        Data.TimeLastJump += Time.deltaTime;
    }

    public virtual void FixedUpdate()
    {
        Vector2 velocity = GetConvertedVecloity();

        Rigidbody.velocity = velocity;
        Rotate(velocity);
    }

    private void Rotate(Vector2 velocity)
    {
        _character.transform.rotation = GetRotationFrom(velocity);
    }

    protected bool IsHorizontalInputZero() => Data.XInput == 0;
    protected bool ReadRunInput() => Input.GetKey(KeyCode.LeftShift);

    private Quaternion GetRotationFrom(Vector3 velocity)
    {
        if (velocity.x > 0)
            return TurnRight;

        if (velocity.x < 0)
            return TurnLeft;

        return _character.transform.rotation;
    }

    private Vector2 GetConvertedVecloity() => new Vector2(Data.XVelocity, Rigidbody.velocity.y);
    protected virtual float ReadHorizontalInput() => Input.GetAxis(Horizontal);
}