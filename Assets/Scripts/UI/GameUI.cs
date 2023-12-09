using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public abstract class GameUI : MonoBehaviour
    {
        [field: SerializeField]
        public bool IsOpened { get; private set; }
        
        public virtual void Open()
        {
            IsOpened = true;
        }

        public virtual void Close()
        {
            IsOpened = false;
        }
    }
}
