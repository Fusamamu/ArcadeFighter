using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    [Serializable]
    public abstract class GameUI : IDisposable
    {
        public bool IsOpened { get; private set; }

        public Transform UIParent;
        
        protected ApplicationStarter application;

        public virtual void Initialized(UIManager _uiManager)
        {
            _uiManager.Add(this);
            application = _uiManager.ApplicationStarter;
        }
        
        public virtual void Open()
        { 
            IsOpened = true;
        }

        public virtual void Close()
        {
            IsOpened = false;
        }
        
        public virtual void Dispose()
        {
        }
    }
}
