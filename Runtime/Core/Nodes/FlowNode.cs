using StateMachine.Core.Actions;
using StateMachine.Core.Connections;
using StateMachine.Core.Graphs;
using StateMachine.Core.Interfaces;
using UnityEngine;
using XNode;

namespace StateMachine.Core.Nodes
{
    public class FlowNode : BaseFlow
    {
        [Input(typeConstraint = TypeConstraint.Inherited)] public ActionConnection actions;
        
        private NodePort actionPort => GetInputPort("actions");

        public override void Start()
        {
            base.Start();
            Start(actionPort);
        }

        public override void Update()
        {
            base.Update();
            Update(actionPort);
        }

        public override void Stop()
        {
            base.Stop();
            Stop(actionPort);
        }
    }
}
