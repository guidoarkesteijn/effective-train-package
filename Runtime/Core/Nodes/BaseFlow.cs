using StateMachine.Core.Connections;
using StateMachine.Core.Graphs;
using StateMachine.Core.Interfaces;
using UnityEngine;
using XNode;

namespace StateMachine.Core.Nodes
{
    public abstract class BaseFlow : Node, IStartable, IStoppable, IUpdatable
    {
        public bool IsStartNode => isStartNode;

        public FlowGraph FlowGraph => graph as FlowGraph;

        [Input] public FlowConnection In;
        [Output(typeConstraint = TypeConstraint.Inherited)] public RuleConnection rules;

        [SerializeField] private bool isStartNode = false;

        protected NodePort inPort => GetInputPort("In");
        protected NodePort rulePort => GetOutputPort("rules");

        public bool Validate(out BaseFlow flowNode)
        {
            return Valid(rulePort, out flowNode);
        }

        public virtual void Start()
        {
            Start(rulePort);
        }

        public virtual void Update()
        {
            Update(rulePort);
        }
        public virtual void Stop()
        {
            Stop(rulePort);
        }

        protected void Start(NodePort port)
        {
            foreach (var item in port.GetConnections())
            {
                if (item.node != null && item.node is IStartable startable)
                {
                    startable.Start();
                }
            }
        }

        protected void Update(NodePort port)
        {
            foreach (var item in port.GetConnections())
            {
                if (item.node != null && item.node is IUpdatable updatable)
                {
                    updatable.Update();
                }
            }
        }

        protected void Stop(NodePort port)
        {
            foreach (var item in port.GetConnections())
            {
                if (item.node != null && item.node is IStoppable stoppable)
                {
                    stoppable.Stop();
                }
            }
        }

        private bool Valid(NodePort port, out BaseFlow flowNode)
        {
            foreach (var item in port.GetConnections())
            {
                if (item.node != null && item.node is IValidatable validatable)
                {
                    if (validatable.Valid)
                    {
                        NodePort outPort = item.node.GetOutputPort("Out");
                        if (outPort.IsConnected)
                        {
                            NodePort connection = outPort.GetConnection(0);
                            if (connection.node is BaseFlow)
                            {
                                flowNode = connection.node as BaseFlow;
                                return true;
                            }
                            else
                            {
                                Debug.LogError("Attached node is not a FlowNode");
                            }
                        }
                        else
                        {
                            Debug.LogError("Rule 'Out' not connected to FlowNode");
                        }
                    }
                }
            }
            flowNode = null;
            return false;
        }

    }
}
