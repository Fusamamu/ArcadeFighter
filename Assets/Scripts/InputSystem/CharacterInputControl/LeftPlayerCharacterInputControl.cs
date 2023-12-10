using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class LeftPlayerCharacterInputControl : CharacterInputControl
    {
        public LeftPlayerCharacterInputControl(InputManager _inputManager, Character _character) : base(_inputManager, _character)
        {
            AddCharacterInputAction<MoveLeftInputAction> (_inputManager.PlayerInput.LeftPlayer.MoveLeft);
            AddCharacterInputAction<MoveRightInputAction>(_inputManager.PlayerInput.LeftPlayer.MoveRight);
            AddCharacterInputAction<AttackInputAction>   (_inputManager.PlayerInput.LeftPlayer.Attack);
            AddCharacterInputAction<BlockInputAction>    (_inputManager.PlayerInput.LeftPlayer.Block);
            AddCharacterInputAction<JumpInputAction>     (_inputManager.PlayerInput.LeftPlayer.Jump);
            AddCharacterInputAction<EvadeInputAction>    (_inputManager.PlayerInput.LeftPlayer.Evade);
        }
    }
}
