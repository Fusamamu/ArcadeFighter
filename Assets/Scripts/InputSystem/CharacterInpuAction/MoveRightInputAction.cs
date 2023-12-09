using UnityEngine.InputSystem;

namespace ArcadeFighter
{
	public class MoveRightInputAction : CharacterInputAction
	{
		private float moveRightValue;
        
		public MoveRightInputAction
		(
			Character    _character, 
			InputAction  _inputAction,
			InputManager _inputManager
		) : base(_character, _inputAction, _inputManager)
		{
		}
        
		public override void Update()
		{
			moveRightValue = TargetInputAction.ReadValue<float>();
			TargetCharacter.MoveRight (moveRightValue);
		}
        
		protected override void OnPressedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnPressedInputHandler(_context);
			TargetCharacter.MoveRight(_context);
		}
        
		protected override void OnReleasedInputHandler(InputAction.CallbackContext _context)
		{
			base.OnReleasedInputHandler(_context);
			TargetCharacter.MoveRight(_context);
		}
	}
}
