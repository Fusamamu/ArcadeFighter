using System;
using System.Collections;
using System.Collections.Generic;

namespace ArcadeFighter
{
    [Serializable]
    public class InputManager
    {
        public PlayerInput PlayerInput;
        
        private readonly Dictionary<PlayerType, CharacterInputControl> inputControlTable = new Dictionary<PlayerType, CharacterInputControl>();

        public InputRecorder InputRecorder = new ();

        public InputManager()
        {
         
        }

        public void Initialized()
        {
            PlayerInput = new PlayerInput();
            PlayerInput.Enable();
        }

        public void UpdateAllInputControls()
        {
            foreach (var _inputControl in inputControlTable.Values)
                _inputControl.Update();
        }
    
        public CharacterInputControl GetControl(Character _character, PlayerType _playerType)
        {
            if (inputControlTable.ContainsKey(_playerType))
                return inputControlTable[_playerType];

            CharacterInputControl _characterInputControl = null;

            switch (_playerType)
            {
                case PlayerType.PLAYER_ONE:
                    _characterInputControl = new LeftPlayerCharacterInputControl(this, _character);
                    break;
                case PlayerType.PLAYER_TWO:
                    _characterInputControl = new RightPlayerInputControl(this, _character);
                    break;
                case PlayerType.AI:
                    _characterInputControl = new LeftPlayerCharacterInputControl(this, _character);
                    break;
            }

            inputControlTable.Add(_playerType, _characterInputControl);

            return _characterInputControl;
        }
    }
}
