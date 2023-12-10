using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class AttackInputAction : CharacterInputAction
	{
		public AttackInputAction
		(
			Character    _character, 
			InputAction  _inputAction, 
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
		}
		
		public override void RunPressedActionCommand()
		{
			TargetCharacter.Attack();
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
			TargetCharacter.Attack(_context);
		}
        
		protected override void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			if(!CanPress())
				return;
			
			base.OnReleasedInputHandler(_context);
			IsTriggerred = false;
		}
	}
}
