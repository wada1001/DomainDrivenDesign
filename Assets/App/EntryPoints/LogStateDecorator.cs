using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.EntryPoints
{
    public class LogStateDecorator : State
    {
        State state;

        public LogStateDecorator(State state) => this.state = state;

        public override string GetKey() => state.GetKey();

        public override void OnEnter()
        {
            Debug.Log("enter state = " + GetKey());
            state.OnEnter();
        }

        public override void OnExit()
        {
            Debug.Log("exit state = " + GetKey());
            state.OnExit();
        }

        public override void OnUpdate()
        {
            state.OnUpdate();
        }
    }
}
