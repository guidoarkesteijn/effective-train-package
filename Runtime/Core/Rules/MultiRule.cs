using StateMachine.Core.Connections;
using StateMachine.Core.Interfaces;
using XNode;

namespace StateMachine.Core.Rules
{
    public class MultiRule : BaseRule
    {
        public override bool Valid
        {
            get
            {
                foreach (var item in rulePort.GetConnections())
                {
                    if (item.IsConnected && item.node is IValidatable validatable)
                    {
                        if(!validatable.Valid)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        private NodePort rulePort => GetInputPort("rules");

        [Input] public FlowConnection rules;
    }
}
