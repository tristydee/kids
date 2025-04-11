namespace Common
{
    public interface IUpdateReceiver
    {
        int Priority { get; }
        void Tick(float delta);
    }
}