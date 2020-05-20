using StateMachine.Core.Connections;
using StateMachine.Core.Interfaces;
using XNode;

namespace StateMachine.Core.Rules
{
    public abstract class BaseRule : Node, IStartable, IStoppable, IValidatable
    {
        public virtual bool Valid { get; }

        [Input] public RuleConnection In;
        [Output] public FlowConnection Out;

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }
    }
}
