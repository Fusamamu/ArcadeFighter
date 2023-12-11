using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class RightPlayerInputControl : CharacterInputControl
    {
        public RightPlayerInputControl(InputManager _inputManager, Character _character) : base(_inputManager, _character)
        {
            AddCharacterInputAction<MoveLeftInputAction>     (_inputManager.PlayerInput.RightPlayer.MoveLeft);
            AddCharacterInputAction<MoveRightInputAction>    (_inputManager.PlayerInput.RightPlayer.MoveRight);
            AddCharacterInputAction<AttackInputAction>       (_inputManager.PlayerInput.RightPlayer.Attack);
            AddCharacterInputAction<BlockInputAction>        (_inputManager.PlayerInput.RightPlayer.Block);
            AddCharacterInputAction<JumpInputAction>         (_inputManager.PlayerInput.RightPlayer.Jump);
            AddCharacterInputAction<EvadeInputAction>        (_inputManager.PlayerInput.RightPlayer.Evade);
            AddCharacterInputAction<SprintForwardInputAction>(_inputManager.PlayerInput.RightPlayer.SprintForward);
        }
    }
}
