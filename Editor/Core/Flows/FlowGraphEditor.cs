using StateMachine.Core.Actions;
using StateMachine.Core.Nodes;
using StateMachine.Core.Rules;
using UnityEngine;
using XNodeEditor;

namespace StateMachine.Core.Graphs
{
    [CustomNodeGraphEditor(typeof(FlowGraph))]
    public class FlowGraphEditor : NodeGraphEditor
    {
        public override void OnGUI()
        {
            //TODO add support for Inner Flow nodes based on a StartFlowGraphNode
            GUILayout.BeginHorizontal();
            GUILayout.Button("MainFlow");
            GUILayout.Label("->");
            GUILayout.Button("SubFlow");
            GUILayout.Label("->");
            GUILayout.Button("SubSubFlow");
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

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
            if(type == typeof(SubFlowNode))
            {
                return "New Start Flow Node";
            }

            return base.GetNodeMenuName(type);
        }
    }
}
