using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class JumpInputAction : CharacterInputAction
	{
		public JumpInputAction
		(
			Character    _character, 
			InputAction  _inputAction, 
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
			InputType = InputType.CLICK;
		}
		
		public override void RunPressedActionCommand()
		{
			TargetCharacter.Jump();
		}
		
		public override void RunReleasedActionCommand()
		{
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			if (InputStateTable.TryGetValue(TargetCharacter.Type, out var _state))
				if (_state.PlayerHoldPress)
					return;
			
			base.OnPressedInputHandler(_context);
			TargetCharacter.Jump();
		}
	}
}
