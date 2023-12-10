using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class BlockInputAction : CharacterInputAction
	{
		public BlockInputAction
		(
			Character    _character, 
			InputAction  _inputAction, 
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
		}
		
		public override void RunPressedActionCommand()
		{
			TargetCharacter.Block();
		}
		
		public override void RunReleasedActionCommand()
		{
			TargetCharacter.UnBlock();
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnPressedInputHandler(_context);
			RunPressedActionCommand();
		}
        
		protected override void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnReleasedInputHandler(_context);
			RunReleasedActionCommand();
		}
	}
}
