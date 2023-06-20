namespace Core
{
    public interface IWorldEvent
    {
        void Execute(IWorld world);
    }
}