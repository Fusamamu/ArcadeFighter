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
			InputType = InputType.CLICK;
		}
		
		public override void RunPressedActionCommand()
		{
			TargetCharacter.Attack();
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			if (InputStateTable.TryGetValue(TargetCharacter.Type, out var _state))
				if (_state.PlayerHoldPress)
					return;
			
			base.OnPressedInputHandler(_context);
			TargetCharacter.Attack(_context);
		}
	}
}
