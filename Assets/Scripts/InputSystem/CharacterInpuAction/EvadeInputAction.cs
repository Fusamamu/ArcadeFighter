using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class EvadeInputAction : CharacterInputAction
	{
		public EvadeInputAction
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
			TargetCharacter.Evade();
		}
		
		public override void RunReleasedActionCommand()
		{
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			if(PlayerHeldPress)
				return;
			
			base.OnPressedInputHandler(_context);
			TargetCharacter.Evade(_context);
		}
	}
}
