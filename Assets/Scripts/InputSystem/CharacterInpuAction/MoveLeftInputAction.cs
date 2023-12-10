using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class MoveLeftInputAction : CharacterInputAction
	{
		private float moveLeftValue = 1;
        
		public MoveLeftInputAction
		(
			Character    _character, 
			InputAction  _inputAction, 
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
		}
        
		public override void Update()
		{
			if (!IsPressed)
			{
				RunReleasedActionCommand();
				return;
			}

			RunPressedActionCommand();
		}
		
		public override void RunPressedActionCommand()
		{
			TargetCharacter.MoveLeft(moveLeftValue);
		}
		
		public override void RunReleasedActionCommand()
		{
			TargetCharacter.MoveLeft(0);
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnPressedInputHandler(_context);
			TargetCharacter.MoveLeft(_context);
		}
        
		protected override void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnReleasedInputHandler(_context);
			TargetCharacter.MoveLeft(_context);
		}
	}
}
