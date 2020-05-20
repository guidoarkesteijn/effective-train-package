using StateMachine.Core.Connections;
using StateMachine.Core.Graphs;
using StateMachine.Core.Interfaces;
using UnityEngine;
using XNode;

namespace StateMachine.Core.Nodes
{
    public class FlowNode : Node, IStartable, IStoppable, IUpdatable
    {
        public FlowGraph FlowGraph => graph as FlowGraph;
        public bool IsStartNode => isStartNode;

        [Input] public FlowConnection In;
        [Input(typeConstraint = TypeConstraint.Inherited)] public ActionConnection actions;
        [Output(typeConstraint = TypeConstraint.Inherited)] public RuleConnection rules;

        [SerializeField] private bool isStartNode = false;

        private NodePort actionPort => GetInputPort("actions");
        private NodePort rulePort => GetOutputPort("rules");

        public void Start()
        {
            Start(actionPort);
            Start(rulePort);
            Debug.Log("StartNode");
        }

        public void Update()
        {
            Update(actionPort);
            Update(rulePort);

            //If valid switch state to rules next node.
        }

        public bool Validate(out FlowNode flowNode)
        {
            return Valid(rulePort, out flowNode);
        }

        public void Stop()
        {
            Stop(actionPort);
            Stop(rulePort);
        }

        private void Start(NodePort port)
        {
            foreach (var item in port.GetConnections())
            {
                if (item.node != null && item.node is IStartable startable)
                {
                    startable.Start();
                }
            }
        }

        private void Update(NodePort port)
        {
            foreach (var item in port.GetConnections())
            {
                if (item.node != null && item.node is IUpdatable updatable)
                {
                    updatable.Update();
                }
            }
        }

        private bool Valid(NodePort port, out FlowNode flowNode)
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
                            if (connection.node is FlowNode)
                            {
                                flowNode = connection.node as FlowNode;
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

        private void Stop(NodePort port)
        {
            foreach (var item in port.GetConnections())
            {
                if (item.node != null && item.node is IStoppable stoppable)
                {
                    stoppable.Stop();
                }
            }
        }
    }
}