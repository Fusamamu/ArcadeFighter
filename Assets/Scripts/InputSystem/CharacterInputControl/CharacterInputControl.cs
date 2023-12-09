using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
    public abstract class CharacterInputControl : IDisposable
    {
        protected Character controlledCharacter;

        protected readonly InputManager inputManager;
        
        protected readonly Dictionary<string, CharacterInputAction> characterInputActionTable = new Dictionary<string, CharacterInputAction>();

        public CharacterInputControl(InputManager _inputManager, Character _character)
        {
            inputManager        = _inputManager;
            controlledCharacter = _character;
        }
     
        protected void AddCharacterInputAction<T>(InputAction _inputAction) where T : CharacterInputAction
        {
            if(Activator.CreateInstance(typeof(T), controlledCharacter, _inputAction, inputManager) is not T _characterInputAction)
                return;
            
            if (!characterInputActionTable.ContainsKey(_characterInputAction.InputActionName))
                characterInputActionTable.Add(_characterInputAction.InputActionName, _characterInputAction);
        }

        public void Update()
        {
            foreach(var _inputAction in characterInputActionTable.Values)
                _inputAction.Update();
        }

        public void Dispose()
        {
            foreach(var _inputAction in characterInputActionTable.Values)
                _inputAction.Dispose();
            
            characterInputActionTable.Clear();
        }
    }
}
