using UnityEditor;
using UnityEngine;

namespace StateMachine.Core.Graphs
{
    [CustomEditor(typeof(FlowGraphStarter))]
    public class FlowGraphStarterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (EditorApplication.isPlaying)
            {
                if (GUILayout.Button("Open Graph Flow"))
                {
                    FlowGraphStarter flowGraphStarter = target as FlowGraphStarter;
                    XNodeEditor.NodeEditorWindow.Open(flowGraphStarter.Instance);
                }
            }
        }
    }
}