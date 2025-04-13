namespace Catching
{
    public class Player : MovingSquare
    {
        public override void Tick(float delta)
        {
            base.Tick(delta);

            if (_input.IsActionPressed)
            {
                //todo: use net
            }
        }
    }
}