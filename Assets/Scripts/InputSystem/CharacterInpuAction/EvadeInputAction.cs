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
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			if (InputStateTable.TryGetValue(TargetCharacter.Type, out var _state))
				if (_state.PlayerHoldPress)
					return;
			
			base.OnPressedInputHandler(_context);
			TargetCharacter.Evade(_context);
		}
	}
}
