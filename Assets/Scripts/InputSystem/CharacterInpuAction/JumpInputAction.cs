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
			if(!CanPress())
				return;

			base.OnPressedInputHandler(_context);
			IsTriggerred = true;
		}
        
		protected override void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			if(!CanPress())
				return;

			base.OnReleasedInputHandler(_context);
			IsTriggerred = false;
			TargetCharacter.Jump(_context);
		}
	}
}
