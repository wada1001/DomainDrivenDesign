using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace App.EntryPoints
{
    public abstract class State
    {
        StateMachine stateMachine;

        public virtual string GetKey() => "";

        public void Enter()
        {
            OnEnter();
        }

        public void Exit()
        {
            OnExit();
        }

        public void Update()
        {
            OnUpdate();
        }

        public virtual void OnEnter() { }
        public virtual void OnExit() { }
        public virtual void OnUpdate() { }
        public void Set(StateMachine stateMachine) => this.stateMachine = stateMachine;
        public void Transition(string key) => stateMachine.Transition(key);
    }
}
