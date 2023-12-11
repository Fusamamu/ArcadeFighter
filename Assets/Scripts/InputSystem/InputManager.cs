using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
    [Serializable]
    public class InputManager
    {
        public PlayerInput PlayerInput;
        
        private readonly Dictionary<PlayerType, CharacterInputControl> inputControlTable = new ();

        public InputRecorder PlayerOneInputRecorder = new ();
        public InputRecorder PlayerTwoInputRecorder = new ();

        private ApplicationStarter applicationStarter;

        private bool isUpdateInputControl;

        public InputManager()
        {
         
        }

        public void StartUpdateInputControl() => isUpdateInputControl = true;
        public void StopUpdateInputControl () => isUpdateInputControl = false;

        public void Initialized(ApplicationStarter _applicationStarter)
        {
            applicationStarter = _applicationStarter;
            
            PlayerInput = new PlayerInput();
            PlayerInput.Disable();
        }

        public void Update()
        {
            if(!isUpdateInputControl)
                return;
            
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
                    break;
            }

            inputControlTable.Add(_playerType, _characterInputControl);

            return _characterInputControl;
        }

        public void StartReplay()
        {
            PlayerOneInputRecorder.StartReplay();
            PlayerTwoInputRecorder.StartReplay();
        }

        public void StopReplay()
        {
            PlayerOneInputRecorder.StopReplay();
            PlayerTwoInputRecorder.StopReplay();
        }

        public void UpdateReplay()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
                applicationStarter.CameraManager.SwitchCamera();
            
            PlayerOneInputRecorder.UpdateReplay();
            PlayerTwoInputRecorder.UpdateReplay();

            if (PlayerOneInputRecorder.IsFinishUpdate && PlayerTwoInputRecorder.IsFinishUpdate)
            {
                ApplicationStarter.GameTime.ResetTime().StopUpdate();
                applicationStarter.StateMachineManager.ChangeState<GameOverState>();
            }
        }

        public void ClearAllRecord()
        {
            PlayerOneInputRecorder.ClearInputRecord();
            PlayerTwoInputRecorder.ClearInputRecord();
        }

        public void RecordInput(PlayerType _type, CharacterInputAction _inputAction)
        {
            switch (_type)
            {
                case PlayerType.PLAYER_ONE:
                    PlayerOneInputRecorder.RecordInput(_inputAction);
                    break;
                case PlayerType.PLAYER_TWO:
                    PlayerTwoInputRecorder.RecordInput(_inputAction);
                    break;
                case PlayerType.AI:
                    break;
            }
        }
    }
}
