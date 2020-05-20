using UnityEngine;

namespace StateMachine.Core.Graphs
{
    public class FlowGraphStarter : MonoBehaviour
    {
        public FlowGraph Instance { get; private set; }

        [SerializeField] private FlowGraph flowNodeGraph = null;

        protected void Awake()
        {
            Instance = flowNodeGraph.InstantiateFlow();
        }

        protected void Start()
        {
            Instance.Start();
        }

        protected void Update()
        {
            Instance.Update();
        }

        protected void LateUpdate()
        {
            Instance.LateUpdate();
        }

        protected void OnDestroy()
        {
            Instance.Stop();
        }
    }
}