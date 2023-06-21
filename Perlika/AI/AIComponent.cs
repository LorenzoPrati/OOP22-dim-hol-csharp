using Components;

namespace AI;

public class AIComponent : IComponent
{
    private readonly List<IAction> _actions;
    private double _currentTime;
    private double _prevTime;
    private IComponent _componentImplementation;

    public AIComponent(List<IAction> newRoutines) => _actions = newRoutines;
    
    public List<IAction> GetRoutine() => _actions;

    public void UpdateTime(double currentTime) => _currentTime += currentTime;
    
    public double GetPrevTime() => _prevTime;

    public void SetPrevTime(double prevTime) => _prevTime = prevTime;
    
    public double GetCurrentTime() => _currentTime;
   
}