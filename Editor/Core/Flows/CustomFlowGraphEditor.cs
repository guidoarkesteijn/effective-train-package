using StateMachine.Core.Actions;
using StateMachine.Core.Nodes;
using StateMachine.Core.Rules;
using XNodeEditor;

namespace StateMachine.Core.Graphs
{
    [CustomNodeGraphEditor(typeof(FlowGraph))]
    public class CustomFlowGraphEditor : NodeGraphEditor
    {
        public override string GetNodeMenuName(System.Type type)
        {
            if (typeof(BaseRule).IsAssignableFrom(type))
            {
                return "Rules/" + type.Name;
            }
            if (typeof(BaseAction).IsAssignableFrom(type))
            {
                return "Actions/" + type.Name;
            }
            if (type == typeof(FlowNode))
            {
                return "New Node";
            }

            return base.GetNodeMenuName(type);
        }
    }
}