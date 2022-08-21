using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;
using System.Linq;

namespace App.EntryPoints
{
    public class StateMachine : IFixedTickable, IInitializable
    {
        Dictionary<string, State> dict = new Dictionary<string, State>();

        State current;
        int frames;

        public StateMachine(IReadOnlyList<State> states)
        {
            foreach (State state in states) Add(state);
        }

        public void Add(State state)
        {
            if (ContainsKey(state.GetKey())) return;

            state.Set(this);
            dict.Add(state.GetKey(), state);
        }

        public void Initialize()
        {
            current = dict.First().Value;
            current.Enter();
        }

        public void FixedTick()
        {
            frames++;
            if (current == null) return;

            current.Update();
        }

        public void Transition(string key)
        {
            if (!ContainsKey(key)) return;
            if (current.GetKey() == key) return;

            current.Exit();
            current = dict[key];
            current.Enter();
        }

        public int GetFrames() => frames;
        public void ResetFrames() => frames = 0;

        bool ContainsKey(string key)
        {
            if (key == "") throw new System.Exception("key is empty");

            return dict.ContainsKey(key);
        }
    }
}
