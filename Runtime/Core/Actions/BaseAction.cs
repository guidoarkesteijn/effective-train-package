using StateMachine.Core.Connections;
using StateMachine.Core.Interfaces;
using XNode;

namespace StateMachine.Core.Actions
{
    public abstract class BaseAction : Node, IStartable, IStoppable
    {
        [Output] public ActionConnection Out;

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }
    }
}