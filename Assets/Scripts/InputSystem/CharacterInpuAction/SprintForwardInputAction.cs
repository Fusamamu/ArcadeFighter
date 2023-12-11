using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class SprintForwardInputAction : CharacterInputAction
	{
		public SprintForwardInputAction
		(
			Character    _character, 
			InputAction  _inputAction, 
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
			InputType = InputType.CLICK;
		}
		
		public override void Update()
		{
		
		}
		
		public override void RunPressedActionCommand()
		{
			TargetCharacter.EvadeSprintForward();
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			if (InputStateTable.TryGetValue(TargetCharacter.Type, out var _state))
				if (_state.PlayerHoldPress)
					return;
			
			base.OnPressedInputHandler(_context);
			TargetCharacter.EvadeSprintForward(_context);
		}
	}
}
