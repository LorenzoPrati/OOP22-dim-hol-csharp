namespace Components
{
    public class AnimationComponent : IComponent
    {
        private readonly Dictionary<string, List<int>> _map = new Dictionary<>();
        private string _state; 
        private string _lastState; 
        public int Index { get; set; }
        public int Counter { get; set; }
        public bool Completed { get; set; }
        public AnimationComponent(Dictionary<string, List<int>> map, string initialState)
        {
            Index = 0;
            // TODO fix copy of the dictionary
            foreach (var s in map)
            {
                _map.Add(s.Key, new List<int>(s.Value));
            }
            _state = initialState;
            _lastState = state;
        }

        public string State => _state;
        public string LastState => _lastState;
        public ReadOnlyDictionary<string, List<int>> Map => new ReadOnlyDictionary<string, List<int>>(_map);
        public void SetState(string newState)
        {
            _lastState = _state;
            _state = newState;
        } 
        public int GetMaxIndex()
        {
            return _map[_state][0];
                
        }
        public int GetImageNumber()
        {
            return _map[_state][1];
        }
        public bool IsBlocking()
        {
            return_map[_state][2] == 1;
        }
    }
}