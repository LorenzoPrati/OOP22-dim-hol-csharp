using Entity;

namespace Core
{
    public class WorldImpl : IWorld
    {

        public IList<IEntity> _entities;
        public IList<IWorldEvent> _events;
        private bool _win;
        public bool GameOver { get; private set; }
        public bool Win 
        { 
            get => _win; 
            set
            {
                _win = value;
                GameOver = true;
            }
        }

        public IList<IEntity> Entities
        {
            get { return new List<IEntity>(_entities); }
        }


        public WorldImpl()
        {
            _entities = new List<IEntity>();
            _events = new List<IWorldEvent>();
        }

        public void Update()
        {
            HandleEvents();
        }

        public void NotifyEvent(IWorldEvent ev)
        {
            _events.Add(ev);
        }

        public void AddEntity(IEntity entity)
        {
            _entities.Add(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            _entities.Remove(entity);
        }

        private void HandleEvents()
        {
            foreach (var ev in _events)
            {
                ev.Execute(this);
            }
            _events.Clear();
        }
    }
}