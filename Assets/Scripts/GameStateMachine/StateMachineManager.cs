using System;
using System.Collections.Generic;

namespace ArcadeFighter
{
    [Serializable]
    public class StateMachineManager
    {
        public GameState CurrentState;

        private readonly Dictionary<Type, GameState> stateTable = new ();

        private ApplicationStarter applicationStarter;

        public StateMachineManager()
        {
            
        }

        public virtual void Initialized(ApplicationStarter _applicationStarter)
        {
            applicationStarter = _applicationStarter;
        }

        public void ChangeState<T>() where T : GameState
        {
            if (!stateTable.TryGetValue(typeof(T), out var _nextState))
            {
                if (Activator.CreateInstance(typeof(T), new object[] { applicationStarter }) is T _state)
                {
                    _nextState = _state;
                    stateTable.Add(typeof(T), _state);
                }
            }
                
            CurrentState?.OnExit();
            CurrentState = _nextState;
            CurrentState?.OnEnter();
        }

        public void Update()
        {
            CurrentState?.OnUpdate();
        }
    }
}
