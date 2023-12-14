public class BaseBullet : Bullet
{
    protected override void Start()
    {
        base.Start();

        Mover = new BaseBulletMovement(this);
        Mover.StartMove();
    }
}

