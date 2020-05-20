
namespace StateMachine.Core.Graphs
{
    public static class FlowGraphExtentions
    {
        public static FlowGraph InstantiateFlow(this FlowGraph flowGraph)
        {
            return flowGraph.Copy() as FlowGraph;
        }
    }
}
