using StateMachine.Core.Graphs;
using UnityEngine;
using XNode;

namespace StateMachine.Core.Nodes
{
    public class SubFlowNode : BaseFlow
    {
        [SerializeField] private FlowGraph flowGraph;
    }
}
