using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class MoveRightInputAction : CharacterInputAction
	{
		private float moveRightValue = 1f;
        
		public MoveRightInputAction
		(
			Character    _character, 
			InputAction  _inputAction,
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
			InputType = InputType.PRESSHOLD;
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
			TargetCharacter.MoveRight(moveRightValue);
		}
		
		public override void RunReleasedActionCommand()
		{
			TargetCharacter.MoveRight(0);
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			if(PlayerHeldPress)
				return;
			
			base.OnPressedInputHandler(_context);
		}
        
		protected override void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnReleasedInputHandler(_context);
		}
	}
}
