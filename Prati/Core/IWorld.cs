using Entity;

namespace Core
{
    public interface IWorld
    {
        void Update();

        void NotifyEvent(IWorldEvent ev);

        IList<IEntity> Entities { get; }

        void AddEntity(IEntity entity);

        void RemoveEntity(IEntity entity);

        bool Win { get; set; }

        bool GameOver { get; }
    }
}