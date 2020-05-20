using StateMachine.Core.Interfaces;
using StateMachine.Core.Nodes;
using System.Linq;
using UnityEngine;
using XNode;

namespace StateMachine.Core.Graphs
{
    [CreateAssetMenu]
    public class FlowGraph : NodeGraph
    {
        private FlowNode CurrentNode;
        private FlowNode[] flowNodes;

        public void Start()
        {
            flowNodes = nodes.Where(x => x.GetType() == typeof(FlowNode)).Cast<FlowNode>().ToArray();
            FlowNode startNode = flowNodes.FirstOrDefault(x => x.IsStartNode);
            SwitchNode(startNode);
        }

        public void Update()
        {
            if (CurrentNode != null && CurrentNode is IUpdatable updatable)
            {
                updatable.Update();
            }
            if (CurrentNode.Validate(out FlowNode newFlowNode))
            {
                SwitchNode(newFlowNode);
            }
        }

        public void LateUpdate()
        {
        }

        public void Stop()
        {
            StopNode(CurrentNode);
        }

        private void SwitchNode(FlowNode nextNode)
        {
            StopNode(CurrentNode);

            CurrentNode = nextNode;

            StartNode(CurrentNode);
        }

        private void StopNode(FlowNode flowNode)
        {
            if (flowNode != null && flowNode is IStoppable stoppable)
            {
                stoppable.Stop();
            }
        }

        private void StartNode(FlowNode flowNode)
        {
            if (flowNode != null && flowNode is IStartable startable)
            {
                startable.Start();
            }
        }

        public override void Clear()
        {
            //WHAT TO DO?
        }

        protected override void OnDestroy()
        {
            //What TO DO
        }
    }
}