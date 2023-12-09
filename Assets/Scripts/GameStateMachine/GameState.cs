using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class GameState : IDisposable
    {
        protected ApplicationStarter application;

        public GameState(ApplicationStarter _application)
        {
            application = _application;
        }
        
        public virtual void OnEnter()
        {
            
        }

        public virtual void OnExit()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }
        
        public void Dispose()
        {
            
        }
    }
}
