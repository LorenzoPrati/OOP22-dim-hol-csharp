using Core;
using Entity;

namespace AI;

public interface IAction
{
    bool CanExecute();
    List<IWorldEvent>? Execute();
    void SetPlayer(IEntity player);
    
    void SetEnemy(IEntity enemy);
}