using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeFighter
{
    public class RightPlayerInputControl : CharacterInputControl
    {
        public RightPlayerInputControl(InputManager _inputManager, Character _character) : base(_inputManager, _character)
        {
            // moveLeftInputAction  = _inputManager.PlayerInput.RightPlayer.MoveLeft;
            // moveRightInputAction = _inputManager.PlayerInput.RightPlayer.MoveRight;
            //
            // Initialized();
        }
    }
}
