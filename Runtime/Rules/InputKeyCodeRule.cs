using StateMachine.Core.Rules;
using UnityEngine;

namespace StateMachine.Rule
{
    public class InputKeyCodeRule : BaseRule
    {
        public override bool Valid => Input.GetKeyDown(keyCode);

        [SerializeField] private KeyCode keyCode = KeyCode.None;

        public override void Start()
        {
            keyCode = KeyCode.Escape;
        }
    }
}