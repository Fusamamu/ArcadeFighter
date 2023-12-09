using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class UIManager : MonoBehaviour
    {
        private Dictionary<Type, GameUI> UITable = new Dictionary<Type, GameUI>();

        public void Initialized()
        {
            var _allUIs = FindObjectsOfType<GameUI>();

            foreach (var _ui in _allUIs)
                Add(_ui);
        }
        
        public T GetUI<T>() where T : GameUI
        {
            if (UITable.ContainsKey(typeof(T)))
                return UITable[typeof(T)] as T;

            return null;
        }

        public void Open<T>() where T : GameUI
        {
            var _ui = GetUI<T>();
            _ui.Open();
        }

        public void Close<T>() where T : GameUI
        {
            var _ui = GetUI<T>();
            _ui.Close();
        }

        public void Add(GameUI _ui)
        {
            if (!UITable.ContainsKey(_ui.GetType()))
                UITable.Add(_ui.GetType(), _ui);
            else
                UITable[_ui.GetType()] = _ui;
        }
        
        public void Remove(GameUI _ui)
        {
            if (UITable.ContainsKey(_ui.GetType()))
                UITable.Remove(_ui.GetType());
        }
    }
}
