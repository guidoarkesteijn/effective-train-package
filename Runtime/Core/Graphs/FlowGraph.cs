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
        private BaseFlow CurrentNode;
        private BaseFlow[] flowNodes;

        public void Start()
        {
            flowNodes = nodes.Where(x => typeof(BaseFlow).IsAssignableFrom(x.GetType())).Cast<BaseFlow>().ToArray();
            BaseFlow startNode = flowNodes.FirstOrDefault(x => x.IsStartNode);
            SwitchNode(startNode);
        }

        public void Update()
        {
            if (CurrentNode != null && CurrentNode is IUpdatable updatable)
            {
                updatable.Update();
            }
            if (CurrentNode.Validate(out BaseFlow newFlowNode))
            {
                SwitchNode(newFlowNode);
            }
        }

        public void LateUpdate()
        {
            if (CurrentNode != null && CurrentNode is ILateUpdatable lateUpdatable)
            {
                lateUpdatable.LateUpdate();
            }
        }

        public void Stop()
        {
            StopNode(CurrentNode);
        }

        private void SwitchNode(BaseFlow nextNode)
        {
            StopNode(CurrentNode);

            CurrentNode = nextNode;

            StartNode(CurrentNode);
        }

        private void StopNode(BaseFlow flowNode)
        {
            if (flowNode != null && flowNode is IStoppable stoppable)
            {
                stoppable.Stop();
            }
        }

        private void StartNode(BaseFlow flowNode)
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
